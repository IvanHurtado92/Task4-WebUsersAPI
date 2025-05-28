using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Task4_WebUsersAPI.DTOs.User
{
    public class CreateUserRequest
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(1, ErrorMessage = "Name must not be empty")]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        [MinLength(1, ErrorMessage = "Email must not be empty")]
        [StringLength(50)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        [MinLength(1, ErrorMessage = "Password must not be empty")]
        [StringLength(50)]
        public string Password { get; set; } = null!;
    }
}
