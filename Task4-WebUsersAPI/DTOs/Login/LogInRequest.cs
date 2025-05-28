using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Task4_WebUsersAPI.DTOs.Login
{
    public class LogInRequest
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        [MinLength(1, ErrorMessage = "Email must not be empty")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(1, ErrorMessage = "Password must not be empty")]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
