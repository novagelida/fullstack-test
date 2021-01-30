using System.ComponentModel.DataAnnotations;

namespace ApiServer.Models.Dto
{
    public class LoginResponse
    {
        [Required]
        public string Token { get; set; }
    }
}
