using Lab.BusinessLogicLayer.Models.DataTransferObjects;
using Lab.BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestResultsController : ControllerBase
    {
        private readonly TestResultService _testResultService;
        public TestResultsController(TestResultService testResultService)
        {
            _testResultService = testResultService;
        }
        // GET: api/<TestResultsController>
        [HttpGet]
        public async Task<ResponseDto<IEnumerable<TestResultDto>>> Get()
        {
            var serviceReponse =  await _testResultService.Get(test => true);
            var returned = new ResponseDto<IEnumerable<TestResultDto>>()
            {
                Data = serviceReponse,
            };
            return  returned;
        }

       

        // POST api/<TestResultsController>
        [HttpPost]
        public async Task<ResponseDto<TestResultDto>> Post([FromBody] TestResultDto value)
        {
            var serviceResponse = await this._testResultService.AddOrUpdate(new() { value });
            return new()
            {
                Data = serviceResponse?.FirstOrDefault()
            };
        }

        
    }
}
