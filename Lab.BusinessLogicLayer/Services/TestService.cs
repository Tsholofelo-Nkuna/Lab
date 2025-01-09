using AutoMapper;
using Lab.BusinessLogicLayer.Models.DataTransferObjects;
using Lab.BusinessLogicLayer.Services.Base;
using Lab.DataAccessLayer.Entities;
using Lab.DataAccessLayer.Interfaces.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.BusinessLogicLayer.Services
{
    public class TestService : ServiceBase<TestDto, TestEntity>
    {
        public TestService(IMapper mapper, IJsonRepository<TestEntity, int> primaryRepo) : base(mapper, primaryRepo)
        {
        }
    }
}
