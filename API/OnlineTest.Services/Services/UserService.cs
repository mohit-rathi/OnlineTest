using OnlineTest.Models;
using OnlineTest.Models.Interfaces;
using OnlineTest.Services.DTO;
using OnlineTest.Services.Interfaces;

namespace OnlineTest.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserDTO> GetUsers()
        {
            var users = _userRepository.GetUsers().Select(user => new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                MobileNo = user.MobileNo,
                Email = user.Email,
                Password = user.Password,
                IsActive = user.IsActive
            }).ToList();
            return users;
        }

        public List<UserDTO> GetUsersPaginated(int pageNumber, int pageSize)
        {
            var users = _userRepository.GetUsersPaginated(pageNumber, pageSize).Select(user => new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                MobileNo = user.MobileNo,
                Email = user.Email,
                Password = user.Password,
                IsActive = user.IsActive
            }).ToList();
            return users;
        }

        public UserDTO GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
                return null;
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                MobileNo = user.MobileNo,
                Email = user.Email,
                Password = user.Password,
                IsActive = user.IsActive
            };
        }

        public UserDTO GetUserByEmail(string email)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user == null)
                return null;
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                MobileNo = user.MobileNo,
                Email = user.Email,
                Password = user.Password,
                IsActive = user.IsActive
            };
        }

        public bool AddUser(UserDTO user)
        {
            return _userRepository.AddUser(new User
            {
                Name = user.Name,
                MobileNo = user.MobileNo,
                Email = user.Email,
                Password = user.Password,
                IsActive = user.IsActive
            });
        }

        public bool UpdateUser(UserDTO user)
        {
            return _userRepository.UpdateUser(new User
            {
                Id = user.Id,
                Name = user.Name,
                MobileNo = user.MobileNo,
                Email = user.Email,
                Password = user.Password,
                IsActive = user.IsActive
            });
        }

        public bool DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }

        public UserDTO IsUserExists(TokenDTO user)
        {
            var result = _userRepository.GetUserByEmail(user.Email);
            if (result == null || result.Password != user.Password)
                return null;
            return new UserDTO
            {
                Id = result.Id,
                Name = result.Name,
                MobileNo = result.MobileNo,
                Email = result.Email,
                Password = result.Password,
                IsActive = result.IsActive
            };
        }
    }
}