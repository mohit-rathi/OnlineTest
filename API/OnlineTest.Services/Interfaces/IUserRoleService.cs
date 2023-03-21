namespace OnlineTest.Services.Interfaces
{
    public interface IUserRoleService
    {
        List<string> GetRoles(int userId);
    }
}