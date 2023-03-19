using OnlineTest.Models.Interfaces;

namespace OnlineTest.Models.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        #region Fields
        private readonly OnlineTestContext _context;
        #endregion

        #region Constructor
        public UserRoleRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public bool AddRole(UserRole role)
        {
            _context.Add(role);
            return _context.SaveChanges() > 0;
        }
        #endregion
    }
}