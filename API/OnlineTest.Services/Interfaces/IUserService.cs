using OnlineTest.Services.DTO;

namespace OnlineTest.Services.Interfaces
{
    public interface IUserService
    {
        ResponseDTO GetUsers();
        ResponseDTO GetUsersPaginated(int page, int limit);
        ResponseDTO GetUserById(int id);
        ResponseDTO GetUserByEmail(string email);
        ResponseDTO AddUser(UserDTO user);
        ResponseDTO UpdateUser(UserDTO user);
        ResponseDTO DeleteUser(int id);
        ResponseDTO IsUserExists(TokenDTO user);
    }
}