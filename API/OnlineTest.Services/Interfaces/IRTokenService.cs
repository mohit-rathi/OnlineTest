using OnlineTest.Services.DTO;

namespace OnlineTest.Services.Interfaces
{
    public interface IRTokenService
    {
        bool AddRefreshToken(RTokenDTO token);
        bool ExpireRefreshToken(RTokenDTO token);
        RTokenDTO GetRefreshToken(string refreshToken);
    }
}