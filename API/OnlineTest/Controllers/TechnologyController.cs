using Microsoft.AspNetCore.Mvc;
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

        #endregion
    }
}