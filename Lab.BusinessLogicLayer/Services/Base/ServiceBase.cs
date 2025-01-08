using AutoMapper;
using Lab.BusinessLogicLayer.Interfaces;
using Lab.BusinessLogicLayer.Models.DataTransferObjects.Base;
using Lab.DataAccessLayer.Entities.Base;
using Lab.DataAccessLayer.Interfaces.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.BusinessLogicLayer.Services.Base
{
    public class ServiceBase<TDto, TEntity> : IServiceBase<TDto, TEntity> where TDto : DtoBase<int> where TEntity : BaseEntity<int>
    {
        protected readonly IMapper mapper;
        protected readonly IJsonRepository<TEntity, int> primaryRepository;
        public ServiceBase(IMapper mapper, IJsonRepository<TEntity, int> primaryRepo) { 
          this.mapper = mapper;
          this.primaryRepository = primaryRepo;
        }

        public async Task<IEnumerable<TDto>> AddOrUpdate(List<TDto> records)
        {
            var updates = this.mapper.Map<List<TEntity>>( records.Where(rec => rec.Id > 0).ToList());
            var inserts = this.mapper.Map<List<TEntity>>(records.Where(rec => rec.Id == 0).ToList());
            var returnedResults = Enumerable.Empty<TDto>().ToList();
            var currentTableState =  (await this.primaryRepository.Get(x => true)).ToList();
            if (inserts.Any())
            {
               var insertResult = await this.primaryRepository.InsertBulk(inserts.ToList());
                returnedResults.AddRange(this.mapper.Map<IEnumerable<TDto>>(insertResult));
            }

            if (updates.Any()) { 
               var updateResults = await this.primaryRepository.UpdateBulk(updates.ToList());
                returnedResults.AddRange(this.mapper.Map<IEnumerable<TDto>>(updateResults));
            }
            return returnedResults;
        }

        public async Task<bool> Delete(IEnumerable<int> identifiers)
        {
           var deleteResponse = await this.primaryRepository.DeleteBulk(identifiers);
            return deleteResponse.Count() == identifiers.Count();
        }
    }
}
