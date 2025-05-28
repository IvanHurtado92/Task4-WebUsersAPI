using Microsoft.AspNetCore.Mvc;
using Task4_WebUsersAPI.DTOs;
using Task4_WebUsersAPI.DTOs.ForgoPassword;
using Task4_WebUsersAPI.DTOs.User;
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

        [HttpPost("[action]")]
        public IActionResult CreateUser([FromBody] CreateUserRequest newUser) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BaseResponse response = _userService.CreateUser(newUser);
            return StatusCode(response.status, response);
        }

        [HttpGet("[action]")]
        public IActionResult GetUsers()
        {
            BaseResponse response = _userService.GetUsers();
            return StatusCode(response.status, response);
        }

        [HttpDelete("[action]")]
        public IActionResult DeleteUser(int id) 
        {
            BaseResponse response = _userService.DeleteUser(id);
            return StatusCode(response.status, response);
        }

        [HttpPatch("[action]")]
        public IActionResult BlockUser(int id) 
        {
            BaseResponse response = _userService.BlockUser(id);
            return StatusCode(response.status, response);
        }

        [HttpPatch("[action]")]
        public IActionResult UnblockUser(int id)
        {
            BaseResponse response = _userService.UnblockUser(id);
            return StatusCode(response.status, response);
        }

        [HttpGet("[action]")]
        public IActionResult IsUserBlocked(int id)
        {
            BaseResponse response = _userService.IsUserBlocked(id);
            return StatusCode(response.status, response);
        }

        [HttpPost("[action]")]
        public IActionResult GetPassword(ForgotPasswordRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BaseResponse response = _userService.GetPassword(request);
            return StatusCode(response.status, response);
        }
    }
}
