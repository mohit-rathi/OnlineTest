using OnlineTest.Models.Interfaces;

namespace OnlineTest.Models.Repository
{
    public class MailOutboundRepository : IMailOutboundRepository
    {
        #region Fields
        private readonly OnlineTestContext _context;
        #endregion

        #region Constructor
        public MailOutboundRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public int AddMailOutbound(MailOutbound mailOutbound)
        {
            _context.Add(mailOutbound);
            if (_context.SaveChanges() > 0)
                return mailOutbound.Id;
            else
                return 0;
        }
        #endregion
    }
}