using Microsoft.AspNetCore.Mvc;
using Task4_WebUsersAPI.DTOs;
using Task4_WebUsersAPI.DTOs.Login;
using Task4_WebUsersAPI.Services;

namespace Task4_WebUsersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly ILoginService _loginService;
        
        public LogInController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("[action]")]
        public IActionResult LogIn([FromBody] LogInRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BaseResponse response = _loginService.LogIn(request);
            return StatusCode(response.status, response);
        }
    }
}
