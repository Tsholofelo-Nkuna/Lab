using AutoMapper;
using Lab.BusinessLogicLayer.Models.DataTransferObjects.Base;
using Lab.DataAccessLayer.Entities.Base;
using Lab.DataAccessLayer.Interfaces.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.BusinessLogicLayer.Interfaces
{
    public interface IServiceBase<TDto, TEntity> where TDto : DtoBase<int> where TEntity : BaseEntity<int>
    {
     
        Task<IEnumerable<TDto>> AddOrUpdate(List<TDto> records);
        Task<bool> Delete(IEnumerable<int> identifiers);
        Task<IEnumerable<TDto>> Get(Func<TEntity, bool> filter);
    }
}
