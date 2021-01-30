using ApiServer.Models.Dto;
using ApiServer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpPost(Name = nameof(Login))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (loginService.UserAlreadyLoggedIn(loginRequest.UserName))
            {
                return BadRequest("User already logged in");
            }

            var autentication = await loginService.AuthenticateUserAsync(loginRequest.UserName, loginRequest.Password);

            if (!autentication.Success)
            {
                return BadRequest(loginService.GetLastError());
            }

            return Ok(autentication.Response.Value);
        }

    }
}
