﻿namespace OnlineTest.Models.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUsersPaginated(int page, int limit);
        User GetUserById(int id);
        User GetUserByEmail(string email);
        bool AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
    }
}