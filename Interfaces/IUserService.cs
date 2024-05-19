using EasyPCIBackend.Models;

namespace EasyPCIBackend.Interfaces
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUser(Guid userId);
        User GetUserByString(string username);
    }
}
