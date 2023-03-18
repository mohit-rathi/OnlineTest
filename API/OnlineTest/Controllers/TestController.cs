using Microsoft.AspNetCore.Mvc;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interfaces;

namespace OnlineTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        #region Fields
        private readonly ITestService _testService;
        #endregion

        #region Constructor
        public TestController(ITestService testService)
        {
            _testService = testService;
        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult GetTests(int page, int limit)
        {
            return Ok(_testService.GetTestsPaginated(page, limit));
        }

        [HttpPost]
        public IActionResult AddTest(AddTestDTO test)
        {
            return Ok(_testService.AddTest(test));
        }

        [HttpPut]
        public IActionResult UpdateTest(UpdateTestDTO test)
        {
            return Ok(_testService.UpdateTest(test));
        }
        #endregion
    }
}