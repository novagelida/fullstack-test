using System;
using ApiServer.Models.Authentication;
using LiteDB;
using System.Threading.Tasks;
using ApiServer.Models;
using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using ApiServer.Models.Dto;

namespace ApiServer.Services
{
    public class LoginService : ILoginService
    {
        private readonly LiteDatabase db;
        private readonly ILogger<UserService> logger;
        private readonly AuthenticationSettings authSettings;

        // In a real world scenario, we can have concurrency issues when dealing with users. A thread-safe data structure
        // can help with that
        private static ConcurrentDictionary<string, User> loggedInUsers = new ConcurrentDictionary<string, User>();
        private string lastError;

        public LoginService(LiteDatabase db, ILogger<UserService> logger, IOptions<AuthenticationSettings> authSettings)
        {
            this.db = db;
            this.logger = logger;
            this.authSettings = authSettings.Value;
        }

        public async Task<AuthenticationObject> AuthenticateUserAsync(string username, string password)
        {
            // The call to GetCollection is sync. If we want to use something different
            // than LiteDb, this call might be async.
            var col = db.GetCollection<User>("users");
            var user = col.Query().Where(u => u.UserName == username && u.Password == password).FirstOrDefault();

            if (user == null)
            {
                return new AuthenticationObject(false, GetLoginErrorResponse(username));
            }

            TryAddLoggedInUser(user);

            return new AuthenticationObject(true, GetLoginSuccessResponse(generateJwtToken(user)));
        }

        public string GetLastError()
        {
            return lastError;
        }

        public bool UserAlreadyLoggedIn(string username)
        {
            User user = null;

            try
            {
                loggedInUsers.TryGetValue(username, out user);
            } catch (Exception e)
            {
                ReportException(e);
            }

            return user != null;
        }

        private ObjectResult GetLoginErrorResponse(string userName)
        {
            return new ObjectResult(new ApiError()
            {
                Message = "User name or password invalid!",
                Detail = "UserName entered: " + userName
            });
        }

        private ObjectResult GetLoginSuccessResponse(string token)
        {
            return new ObjectResult(new LoginResponse()
            {
                Token = token,
            });
        }

        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(authSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private void TryAddLoggedInUser(User user)
        {
            try
            {
                loggedInUsers.TryAdd(user.UserName, user);
            }
            catch (Exception e)
            {
                ReportException(e);
            }
        }

        private void ReportException(Exception e)
        {
            logger.LogError(e.Message, e.StackTrace);

            lastError = e.Message;
        }
    }
}
