using OnlineTest.Services.DTO;

namespace OnlineTest.Services.Interfaces
{
    public interface IUserService
    {
        List<UserDTO> GetUsers();
        bool AddUser(UserDTO user);
        bool UpdateUser(UserDTO user);
        bool DeleteUser(int id);
    }
}