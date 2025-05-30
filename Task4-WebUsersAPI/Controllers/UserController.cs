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
        public IActionResult DeleteUser([FromBody] int[] ids) 
        {
            BaseResponse response = _userService.DeleteUser(ids);
            return StatusCode(response.status, response);
        }

        [HttpPost("[action]")]
        public IActionResult BlockUser([FromBody] int[] ids) 
        {
            BaseResponse response = _userService.BlockUser(ids);
            return StatusCode(response.status, response);
        }

        [HttpPost("[action]")]
        public IActionResult UnblockUser([FromBody] int[] ids)
        {
            BaseResponse response = _userService.UnblockUser(ids);
            return StatusCode(response.status, response);
        }

        [HttpPost("[action]")]
        public IActionResult IsUserBlocked([FromBody] ForgotPasswordRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BaseResponse response = _userService.IsUserBlocked(request);
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
