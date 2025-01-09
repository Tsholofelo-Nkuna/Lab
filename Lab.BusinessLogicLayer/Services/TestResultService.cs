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
    public class TestResultService : ServiceBase<TestResultDto, TestResultEntity>
    {
        public TestResultService(IMapper mapper, IJsonRepository<TestResultEntity, int> primaryRepo) : base(mapper, primaryRepo)
        {
        }
    }
}
