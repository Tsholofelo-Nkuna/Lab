using Lab.DataAccessLayer.Entities.Base;
using Lab.DataAccessLayer.Interfaces.Json;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab.DataAccessLayer.Repositories.Json
{
    public class JsonRepository<TEntity> : IJsonRepository<TEntity, int> where TEntity : BaseEntity<int>
    {
        private string _jsonFilePath = string.Empty;
        public static object fileLock = new object();
        public JsonRepository(IOptions<JsonRepositoryOptions<TEntity>> options)
        {
            _jsonFilePath = options.Value.FilePath;
            if (options.Value.SeedData is List<TEntity> seedData)
            {
                var isInitialized = Init(seedData).Result;
            }
        }

        public int InsertId
        {
            get
            {
                return Get(x => true).Result.Count() + 1;
            }
        }

        public async Task<IEnumerable<TEntity>> Get(Func<TEntity, bool> predicate)
        {
            if (File.Exists(_jsonFilePath))
            {
                lock (fileLock)
                {
                    var jsonString = File.ReadAllTextAsync(_jsonFilePath).Result;
                    var records = JsonSerializer.Deserialize<IEnumerable<TEntity>>(jsonString) ?? Enumerable.Empty<TEntity>();
                    return records.Where(predicate) ?? Enumerable.Empty<TEntity>();
                }
            }
            else
            {
                return Enumerable.Empty<TEntity>();
            }
        }

        public async Task<IEnumerable<TEntity>> InsertBulk(List<TEntity> entities)
        {
            var insertId = InsertId;
            entities.ForEach(rec =>
            {
                rec.Id = insertId;
                insertId += 1;
            });
            var insertIdentifiers = entities.Select(rec => rec.Id);
            lock (fileLock)
            {
                if (!File.Exists(_jsonFilePath))
                {


                    File.AppendAllText(_jsonFilePath, JsonSerializer.Serialize(entities));
                }
                else
                {
                    var existingRecords = Get(x => true).Result.ToList();
                    existingRecords.AddRange(entities);
                    File.WriteAllText(_jsonFilePath, JsonSerializer.Serialize(existingRecords));
                }
            }

            return await Get(rec => insertIdentifiers.Contains(rec.Id));
        }

        public Task<TEntity?> GetById(int id)
        {
            if (File.Exists(_jsonFilePath))
            {
                lock (fileLock)
                {
                    return Task.FromResult(Get(x => x.Id == id).Result.FirstOrDefault());
                }
            }
            else
            {
                return default;
            }
        }

        public async Task<IEnumerable<TEntity>> DeleteBulk(IEnumerable<int> identifiers)
        {
            var deleted = await Get(x => identifiers.Contains(x.Id));
            var validRecords = Get(x => !identifiers.Contains(x.Id));
            if (!File.Exists(_jsonFilePath))
            {
                return Enumerable.Empty<TEntity>();
            }
            lock (fileLock)
            {
                File.WriteAllText(_jsonFilePath, JsonSerializer.Serialize(validRecords));
            }
            return deleted ?? Enumerable.Empty<TEntity>();
        }

        public Task<IEnumerable<TEntity>> UpdateBulk(List<TEntity> updates)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Init(List<TEntity> seedData)
        {
            var currentRepoContent = await Get(rec => true);
            if (currentRepoContent is IEnumerable<TEntity> repoContent && !repoContent.Any())
            {
                var inserted = await InsertBulk(seedData);
                return inserted.All(x => x.Id > 0) && inserted.Count() == seedData.Count();
            }
            else
            {
                return false;
            }
        }
    }
}
