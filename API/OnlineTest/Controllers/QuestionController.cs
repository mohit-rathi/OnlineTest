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
        public IActionResult GetQuestionsByTestId(int testId)
        {
            return Ok(_questionService.GetQuestionsByTestId(testId));
        }

        [HttpPost]
        public IActionResult AddQuestion(QuestionDTO question)
        {
            return Ok(_questionService.AddQuestion(question));
        }

        [HttpPut]
        public IActionResult UpdateQuestion(QuestionDTO question)
        {
            return Ok(_questionService.UpdateQuestion(question));
        }
        #endregion
    }
}