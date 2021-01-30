using System.ComponentModel.DataAnnotations;

namespace ApiServer.Models.Dto
{
    public class LoginRequest
    {
        [Required]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "User name must be between 4 and 30 characters long")]
        public string UserName { get; set; }

        [Required]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Password must be 4 characters long")]
        public string Password { get; set; }
    }
}
