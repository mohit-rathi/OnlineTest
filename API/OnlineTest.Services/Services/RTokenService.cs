using OnlineTest.Models;
using OnlineTest.Models.Interfaces;
using OnlineTest.Services.DTO;
using OnlineTest.Services.Interfaces;

namespace OnlineTest.Services.Services
{
    public class RTokenService : IRTokenService
    {
        private readonly IRTokenRepository _rTokenRepository;

        public RTokenService(IRTokenRepository rTokenRepository)
        {
            _rTokenRepository = rTokenRepository;
        }

        public bool AddRefreshToken(RTokenDTO token)
        {
            return _rTokenRepository.AddRefreshToken(new RToken
            {
                RefreshToken = token.RefreshToken,
                IsStop = token.IsStop,
                CreatedDate = token.CreatedDate,
                UserId = token.UserId
            });
        }

        public bool ExpireRefreshToken(RTokenDTO token)
        {
            return _rTokenRepository.ExpireRefreshToken(new RToken
            {
                RefreshToken = token.RefreshToken,
                IsStop = token.IsStop,
                CreatedDate = token.CreatedDate,
                UserId = token.UserId
            });
        }

        public RTokenDTO GetRefreshToken(string refreshToken)
        {
            var result = _rTokenRepository.GetRefreshToken(refreshToken);
            if (result == null)
                return null;
            return new RTokenDTO
            {
                RefreshToken = result.RefreshToken,
                IsStop = result.IsStop,
                CreatedDate = result.CreatedDate,
                UserId = result.UserId
            };
        }
    }
}