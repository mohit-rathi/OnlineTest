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

        public ResponseDTO GetUsers()
        {
            var response = new ResponseDTO();
            try
            {
                var users = _userRepository.GetUsers()
                    .Select(user => new UserDTO
                    {
                        Id = user.Id,
                        Name = user.Name,
                        MobileNo = user.MobileNo,
                        Email = user.Email,
                        Password = user.Password,
                        IsActive = user.IsActive
                    }).ToList();
                response.Status = 200;
                response.Message = "Ok";
                response.Data = users;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO GetUsersPaginated(int page, int limit)
        {
            var response = new ResponseDTO();
            try
            {
                var users = _userRepository.GetUsersPaginated(page, limit)
                    .Select(user => new UserDTO
                    {
                        Id = user.Id,
                        Name = user.Name,
                        MobileNo = user.MobileNo,
                        Email = user.Email,
                        Password = user.Password,
                        IsActive = user.IsActive
                    }).ToList();
                response.Status = 200;
                response.Message = "Ok";
                response.Data = users;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
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

        public ResponseDTO AddUser(UserDTO user)
        {
            var response = new ResponseDTO();
            try
            {
                var userByEmail = GetUserByEmail(user.Email);
                if (userByEmail != null)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Email already exists";
                    return response;
                }
                var result = _userRepository.AddUser(new User
                {
                    Name = user.Name,
                    MobileNo = user.MobileNo,
                    Email = user.Email,
                    Password = user.Password,
                    IsActive = user.IsActive
                });
                if (result)
                {
                    response.Status = 204;
                    response.Message = "Created";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Could not add user";
                }
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO UpdateUser(UserDTO user)
        {
            var response = new ResponseDTO();
            try
            {
                var userById = GetUserById(user.Id);
                if (userById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "User not found";
                    return response;
                }
                var userByEmail = GetUserByEmail(user.Email);
                if (userByEmail != null && userByEmail.Id != user.Id)
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Email already exists";
                    return response;
                }
                var result = _userRepository.UpdateUser(new User
                {
                    Id = user.Id,
                    Name = user.Name,
                    MobileNo = user.MobileNo,
                    Email = user.Email,
                    Password = user.Password,
                    IsActive = user.IsActive
                });
                if (result)
                {
                    response.Status = 204;
                    response.Message = "Updated";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Could not update user";
                }
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO DeleteUser(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var userById = GetUserById(id);
                if (userById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "User not found";
                    return response;
                }
                var result = _userRepository.DeleteUser(id);
                if (result)
                {
                    response.Status = 204;
                    response.Message = "Deleted";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Deleted";
                    response.Error = "Could not delete user";
                }
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
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