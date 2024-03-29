﻿using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interfaces;

namespace OnlineTest.Controllers
{
    [Route("api/technologies")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class TechnologyController : ControllerBase
    {
        #region Fields
        private readonly ITechnologyService _technologyService;
        #endregion

        #region Constructor
        public TechnologyController(ITechnologyService technologyService)
        {
            _technologyService = technologyService;
        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult GetTechnologies()
        {
            return Ok(_technologyService.GetTechnologies());
        }

        [HttpGet("paginated")]
        public IActionResult GetTechnologiesPaginated(int page, int limit)
        {
            return Ok(_technologyService.GetTechnologiesPaginated(page, limit));
        }

        [HttpGet("id")]
        public IActionResult GetTechnologyById(int id)
        {
            return Ok(_technologyService.GetTechnologyById(id));
        }

        [HttpPost]
        public IActionResult AddTechnology(AddTechnologyDTO technology)
        {
            return Ok(_technologyService.AddTechnology(Convert.ToInt32(User.FindFirstValue("Id")), technology));
        }

        [HttpPut]
        public IActionResult UpdateTechnology(UpdateTechnologyDTO technology)
        {
            return Ok(_technologyService.UpdateTechnology(Convert.ToInt32(User.FindFirstValue("Id")), technology));
        }

        [HttpDelete]
        public IActionResult DeleteTechnology(int id)
        {
            return Ok(_technologyService.DeleteTechnology(id));
        }
        #endregion
    }
}