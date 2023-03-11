using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTest.Services.DTO;
using OnlineTest.Services.Interfaces;

namespace OnlineTest.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
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
        public ActionResult<UserDTO> GetUsers(int? page, int? limit)
        {
            List<UserDTO> data;
            if (page.HasValue && limit.HasValue)
                data = _userService.GetUsersPaginated(page.Value, limit.Value);
            else
                data = _userService.GetUsers();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult AddUser(UserDTO user)
        {
            var result = _userService.GetUserByEmail(user.Email);
            if (result != null)
            {
                return BadRequest("Email already exists");
            }
            return Ok(_userService.AddUser(user));
        }

        [HttpPut]
        public IActionResult UpdateUser(UserDTO user)
        {
            var result = _userService.GetUserById(user.Id);
            if (result == null)
            {
                return NotFound("User not found");
            }
            result = _userService.GetUserByEmail(user.Email);
            if (result != null && result.Id != user.Id)
            {
                return BadRequest("Email already exists");
            }
            return Ok(_userService.UpdateUser(user));
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            var result = _userService.GetUserById(id);
            if (result == null)
            {
                return NotFound("User not found");
            }
            return Ok(_userService.DeleteUser(id));
        }
        #endregion
    }
}