using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineTest.Services.DTO;
using OnlineTest.Services.Interfaces;

namespace OnlineTest.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Fields
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public AuthController(IUserService userService, IUserRoleService userRoleService, IConfiguration configuration)
        {
            _userService = userService;
            _userRoleService = userRoleService;
            _configuration = configuration.GetSection("JWTConfig");
        }
        #endregion

        #region Methods
        [HttpPost("login")]
        public IActionResult Login(LoginDTO user)
        {
            // check if user exists
            var result = _userService.IsUserExists(user);
            if (result == null)
            {
                return Ok(new ResponseDTO
                {
                    Status = 401,
                    Message = "Unauthorized",
                    Error = "Incorrect email or password."
                });
            }

            var response = GetJwt(result.Id, result.Email);
            return Ok(response);
        }

        private object GetJwt(int userId, string email)
        {
            var now = DateTime.UtcNow;

            // jwt claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Iat, now.ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64),
                new Claim("Id", Convert.ToString(userId)),
                new Claim("Email", email)
            };
            var roles = _userRoleService.GetRoles(userId);
            foreach (var role in roles)
            {
                claims.Add(new Claim("Role", role));
            }

            // signing key
            var symmetricKeyAsBase64 = _configuration["SecretKey"];
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);

            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            // token options
            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["Issuer"],
                audience: _configuration["Audience"],
                claims: claims,
                expires: now.Add(TimeSpan.FromHours(24)),
                signingCredentials: signingCredentials
            );

            // active token
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            // create and return response
            var response = new
            {
                Status = 200,
                Message = "Authorized",
                Data = new {
                    Id = userId,
                    Email = email,
                    Token = tokenString,
                    ExpiresIn = (int)TimeSpan.FromHours(24).TotalSeconds
                }
            };
            return response;
        }
        #endregion
    }
}