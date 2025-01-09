using Lab.BusinessLogicLayer.Models.DataTransferObjects;
using Lab.BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestRequisitionsController : ControllerBase
    {
        private readonly TestRequisitionService _testRequisitionService;
        public TestRequisitionsController(TestRequisitionService testRequisitionService) { 
           _testRequisitionService = testRequisitionService;
        }
        // GET: api/<TestRequisitionsController>
        [HttpGet]
        public async Task<ResponseDto<IEnumerable<RequisitionDto>>> Get()
        {
            var response = new ResponseDto<IEnumerable<RequisitionDto>>()
            {
                Data = await _testRequisitionService.Get(x => true)
            };
            return response;
        }

      
        // POST api/<TestRequisitionsController>
        [HttpPost]
        public async Task<ResponseDto<RequisitionDto?>> Post([FromBody] RequisitionDto value)
        {
            var serviceResponse = await this._testRequisitionService.AddOrUpdate(new() { value });
            return new ResponseDto<RequisitionDto?>() { 
                Data = serviceResponse?.FirstOrDefault()
            };
        }
    }
}
