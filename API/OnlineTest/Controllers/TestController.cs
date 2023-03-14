using Microsoft.AspNetCore.Mvc;
using OnlineTest.Services.DTO;
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
        public ActionResult<TestDTO> GetTests(int? page, int? limit)
        {
            List<TestDTO> data;
            if (page.HasValue && limit.HasValue)
                data = _testService.GetTestsPaginated(page.Value, limit.Value);
            else
                data = _testService.GetTests();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult AddTest(TestDTO test)
        {
            bool result = _testService.AddTest(test);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateTest(TestDTO test)
        {
            bool result = _testService.UpdateTest(test);
            return Ok(result);
        }
        #endregion
    }
}