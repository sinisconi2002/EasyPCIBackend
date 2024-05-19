using EasyPCIBackend.Models;
using EasyPCIBackend.Models.Dtos;

namespace EasyPCIBackend.Interfaces
{
    public interface ISigningService
    {
        Task RegisterUser(User user);
        bool ValidateUser(LoginUser attempt);
    }
}