using Microsoft.AspNetCore.Mvc;
using Task4_WebUsersAPI.DTOs;
using Task4_WebUsersAPI.Models;
using Task4_WebUsersAPI.Services;

namespace Task4_WebUsersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("[action]")]
        public IActionResult GetUsers()
        {
            BaseResponse response = _userService.GetUsers();
            return StatusCode(response.status, response);
        }
    }
}
