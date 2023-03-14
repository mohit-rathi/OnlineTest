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
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Fields
        private readonly IUserService _userService;
        private readonly IRTokenService _rTokenService;
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public AuthController(IUserService userService, IRTokenService rTokenService, IConfiguration configuration)
        {
            _userService = userService;
            _rTokenService = rTokenService;
            _configuration = configuration.GetSection("JWTConfig");
        }
        #endregion

        #region Methods
        [HttpPost("login")]
        public IActionResult Login(TokenDTO user)
        {
            // data validation
            if (user == null || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("Invalid login credentials");
            }

            // check if user exists
            var result = _userService.IsUserExists(user);
            if (result == null)
            {
                return Unauthorized("Invalid login credentials");
            }

            // create and add refresh token in database
            string refreshToken = Guid.NewGuid().ToString().Replace("-", "");
            RTokenDTO rToken = new RTokenDTO
            {
                RefreshToken = refreshToken,
                IsStop = false,
                CreatedDate = DateTime.UtcNow,
                UserId = result.Id
            };
            if (!_rTokenService.AddRefreshToken(rToken))
            {
                return Unauthorized("Failed to add refresh token");
            }

            // create access token and send response
            var response = GetJwt(rToken);
            return Ok(response);
        }

        [HttpPost("refresh")]
        public IActionResult RefreshToken(TokenDTO user)
        {
            // data validation
            if (user == null || string.IsNullOrEmpty(user.RefreshToken))
            {
                return BadRequest("Refresh token is required");
            }

            // check if refresh token exists or expired
            var rTokenOld = _rTokenService.GetRefreshToken(user.RefreshToken);
            if (rTokenOld == null)
            {
                return Unauthorized("Refresh token not found");
            }
            if (rTokenOld.IsStop == true)
            {
                return Unauthorized("Refresh token has expired");
            }

            // expire old refresh token and create new refresh token
            rTokenOld.IsStop = true;
            bool updateFlag = _rTokenService.ExpireRefreshToken(rTokenOld);
            string refreshToken = Guid.NewGuid().ToString().Replace("-", "");
            var rTokenNew = new RTokenDTO
            {
                RefreshToken = refreshToken,
                IsStop = false,
                CreatedDate = DateTime.UtcNow,
                UserId = rTokenOld.UserId
            };
            bool addFlag = _rTokenService.AddRefreshToken(rTokenNew);
            if (!updateFlag || !addFlag)
            {
                return Unauthorized("Could not refresh token");
            }

            // create access token and send response
            var response = GetJwt(rTokenNew);
            return Ok(response);
        }

        private object GetJwt(RTokenDTO rToken)
        {
            var now = DateTime.UtcNow;
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "jwt_token"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64),
                new Claim("Id", Convert.ToString(rToken.UserId))
            };
            var symmetricKeyAsBase64 = _configuration["SecretKey"];
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["Issuer"],
                audience: _configuration["Audience"],
                claims: claims,
                expires: now.Add(TimeSpan.FromHours(24)),
                signingCredentials: signingCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            var response = new
            {
                id = rToken.UserId,
                access_token = tokenString,
                refresh_token = rToken.RefreshToken,
                expires_in = (int)TimeSpan.FromHours(24).TotalSeconds
            };
            return response;
        }
        #endregion
    }
}