using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTest.Services.DTO;
using OnlineTest.Services.Interfaces;

namespace OnlineTest.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Fields
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult GetUsers(int page, int limit)
        {
            return Ok(_userService.GetUsersPaginated(page, limit));
        }

        [HttpPost]
        public IActionResult AddUser(UserDTO user)
        {
            return Ok(_userService.AddUser(user));
        }

        [HttpPut]
        public IActionResult UpdateUser(UserDTO user)
        {
            return Ok(_userService.UpdateUser(user));
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            return Ok(_userService.DeleteUser(id));
        }
        #endregion
    }
}