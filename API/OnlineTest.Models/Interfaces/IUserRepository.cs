namespace OnlineTest.Models.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        bool AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
    }
}