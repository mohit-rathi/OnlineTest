using OnlineTest.Models.Interfaces;

namespace OnlineTest.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly OnlineTestContext _context;

        public UserRepository(OnlineTestContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        
        public IEnumerable<User> GetUsersPaginated(int page, int limit)
        {
            return _context.Users.Skip((page - 1) * limit).Take(limit).ToList();
        }
        
        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
        
        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public bool AddUser(User user)
        {
            _context.Users.Add(user);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateUser(User user)
        {
            _context.Entry(user).Property("Name").IsModified = true;
            _context.Entry(user).Property("MobileNo").IsModified = true;
            _context.Entry(user).Property("Email").IsModified = true;
            _context.Entry(user).Property("Password").IsModified = true;
            _context.Entry(user).Property("IsActive").IsModified = true;
            return _context.SaveChanges() > 0;
        }

        public bool DeleteUser(int id)
        {
            var entity = _context.Users.FirstOrDefault(u => u.Id == id);
            if (entity != null)
            {
                _context.Remove(entity);
            }
            return _context.SaveChanges() > 0;
        }
    }
}