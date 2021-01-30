using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Models.Authentication
{
    public class AuthenticationObject
    {
        public bool Success { private set; get; }

        public ObjectResult Response { private set; get; }

        public AuthenticationObject(bool success, ObjectResult response)
        {
            this.Success = success;
            this.Response = response;
        }
    }
}
