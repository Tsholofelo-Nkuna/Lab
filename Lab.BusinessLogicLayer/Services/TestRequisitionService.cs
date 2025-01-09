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
    public class TestRequisitionService : ServiceBase<RequisitionDto, RequisitionEntity>
    {
        private readonly IJsonRepository<TestEntity, int> _testRepository;
        public TestRequisitionService(
            IMapper mapper,
            IJsonRepository<RequisitionEntity, int> primaryRepo,
            IJsonRepository<TestEntity, int> testRepo
            ) : base(mapper, primaryRepo)
        {
            _testRepository = testRepo;
        }

        public override async Task<IEnumerable<RequisitionDto>> Get(Func<RequisitionEntity, bool> filter)
        {
            var baseResult =  await base.Get(filter);
            if (baseResult is IEnumerable<RequisitionDto> result) {
             var returnedRequisitions  = result.Select( req =>
                {
                    var tests = ( _testRepository.Get(test => req.RequestedTestIdentifiers.Contains(test.Id))).Result.ToList();
                    req.RequestedTests = this.mapper.Map<List<TestDto>>( tests);
                    return req;
                });
                return returnedRequisitions;
            }
            else
            {
                return Enumerable.Empty<RequisitionDto>();
            }
        }
    }
}
