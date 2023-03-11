namespace OnlineTest.Models.Interfaces
{
    public interface IRTokenRepository
    {
        bool AddRefreshToken(RToken token);
        bool ExpireRefreshToken(RToken token);
        RToken GetRefreshToken(string refreshToken);
    }
}