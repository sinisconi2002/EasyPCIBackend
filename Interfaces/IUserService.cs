using EasyPCIBackend.Models;

namespace EasyPCIBackend.Interfaces
{
    public interface IUserService
    {
        User GetUserByString(string username);
    }
}
