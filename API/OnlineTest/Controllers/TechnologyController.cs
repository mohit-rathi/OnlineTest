using Microsoft.AspNetCore.Mvc;
using OnlineTest.Services.DTO;
using OnlineTest.Services.Interfaces;

namespace OnlineTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public IActionResult GetTechnologies(int page, int limit)
        {
            return Ok(_technologyService.GetTechnologiesPaginated(page, limit));
        }

        [HttpPost]
        public IActionResult AddTechnology(TechnologyDTO technology)
        {
            return Ok(_technologyService.AddTechnology(technology));
        }

        [HttpPut]
        public IActionResult UpdateTechnology(TechnologyDTO technology)
        {
            return Ok(_technologyService.UpdateTechnology(technology));
        }
        #endregion
    }
}