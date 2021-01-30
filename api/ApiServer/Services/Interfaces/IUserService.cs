using ApiServer.Models;
using System.Threading.Tasks;

namespace ApiServer.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(int userId);
    }
}
