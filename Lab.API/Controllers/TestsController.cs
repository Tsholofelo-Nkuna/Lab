using Lab.BusinessLogicLayer.Models.DataTransferObjects;
using Lab.BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly TestService _testService;
        public TestsController(TestService testService) {
          _testService = testService;
        }
        // GET: api/<TestsController>
        [HttpGet]
        public async Task<ResponseDto<IEnumerable<TestDto>>> Get()
        {
            var serviceResponse = await _testService.Get(test => true);
            return new ()
            {
                Data = serviceResponse
            };
        }

     
    }
}
