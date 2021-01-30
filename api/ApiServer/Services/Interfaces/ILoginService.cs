using ApiServer.Models.Authentication;
using System.Threading.Tasks;

namespace ApiServer.Services
{
    public interface ILoginService
    {
        bool UserAlreadyLoggedIn(string username);

        Task<AuthenticationObject> AuthenticateUserAsync(string username, string password);

        string GetLastError();
    }
}
