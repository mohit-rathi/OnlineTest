﻿using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interfaces;

namespace OnlineTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnswerController : ControllerBase
    {
        #region Fields
        private readonly IAnswerService _answerService;
        #endregion

        #region Constructor
        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult GetAnswersByQuestionId(int id)
        {
            return Ok(_answerService.GetAnswersByQuestionId(id));
        }

        [HttpPost]
        public IActionResult AddAnswer(AddAnswerDTO answer)
        {
            return Ok(_answerService.AddAnswer(Convert.ToInt32(User.FindFirstValue("Id")), answer));
        }

        [HttpPut]
        public IActionResult UpdateAnswer(UpdateAnswerDTO answer)
        {
            return Ok(_answerService.UpdateAnswer(answer));
        }

        [HttpDelete]
        public IActionResult DeleteAnswer(int id)
        {
            return Ok(_answerService.DeleteAnswer(id));
        }
        #endregion
    }
}