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
            try
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
            catch (Exception e)
            {
                throw e;
            }
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
    }
}