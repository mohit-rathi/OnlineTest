using OnlineTest.Services.DTO;

namespace OnlineTest.Services.Interfaces
{
    public interface IUserService
    {
        List<UserDTO> GetUsers();
        List<UserDTO> GetUsersPaginated(int pageNumber, int pageSize);
        UserDTO GetUserById(int id);
        UserDTO GetUserByEmail(string email);
        bool AddUser(UserDTO user);
        bool UpdateUser(UserDTO user);
        bool DeleteUser(int id);
        UserDTO IsUserExists(TokenDTO user);
    }
}