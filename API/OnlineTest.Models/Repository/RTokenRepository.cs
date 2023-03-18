using OnlineTest.Models.Interfaces;

namespace OnlineTest.Models.Repository
{
    public class RTokenRepository : IRTokenRepository
    {
        #region Fields
        private readonly OnlineTestContext _context;
        #endregion

        #region Constructor
        public RTokenRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public bool AddRefreshToken(RToken token)
        {
            _context.RTokens.Add(token);
            return _context.SaveChanges() > 0;
        }

        public bool ExpireRefreshToken(RToken token)
        {
            _context.Update(token);
            return _context.SaveChanges() > 0;
        }

        public RToken GetRefreshToken(string refreshToken)
        {
            return _context.RTokens.FirstOrDefault(x => x.RefreshToken == refreshToken);
        }
        #endregion
    }
}