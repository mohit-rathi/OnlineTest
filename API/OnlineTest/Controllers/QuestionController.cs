using Microsoft.AspNetCore.Mvc;
using OnlineTest.Services.DTO;
using OnlineTest.Services.Interfaces;

namespace OnlineTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        #region Fields
        private readonly IQuestionService _questionService;
        #endregion

        #region Constructor
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        #endregion

        #region Methods
        [HttpGet]
        public ActionResult<QuestionDTO> GetQuestionsByTestId(int testId)
        {
            List<QuestionDTO> data = _questionService.GetQuestionsByTestId(testId);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult AddQuestion(QuestionDTO question)
        {
            bool result = _questionService.AddQuestion(question);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateQuestion(QuestionDTO question)
        {
            bool result = _questionService.UpdateQuestion(question);
            return Ok(result);
        }
        #endregion
    }
}