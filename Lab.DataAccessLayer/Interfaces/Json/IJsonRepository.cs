using Lab.DataAccessLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.DataAccessLayer.Interfaces.Json
{
    public interface IJsonRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public Task<IEnumerable<TEntity>> Get(Func<TEntity, bool> predicate);
        public Task<IEnumerable<TEntity>> InsertBulk(List<TEntity> entities);
        public Task<TEntity?> GetById(TKey id);
        public Task<IEnumerable<TEntity>> DeleteBulk(IEnumerable<TKey> identifiers);
        public Task<IEnumerable<TEntity>> UpdateBulk(List<TEntity> updates);
        public TKey InsertId { get; }
        public Task<bool> Init(List<TEntity> seedData);

    }
}
