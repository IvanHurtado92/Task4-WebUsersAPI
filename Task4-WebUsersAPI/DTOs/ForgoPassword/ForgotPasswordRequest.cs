using System.ComponentModel.DataAnnotations;

namespace Task4_WebUsersAPI.DTOs.ForgoPassword
{
    public class ForgotPasswordRequest
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        [MinLength(1, ErrorMessage = "Email must not be empty")]
        [StringLength(50)]
        public string Email { get; set; }
    }
}
