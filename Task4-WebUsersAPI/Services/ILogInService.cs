using Task4_WebUsersAPI.DTOs;
using Task4_WebUsersAPI.DTOs.Login;

namespace Task4_WebUsersAPI.Services
{
    public interface ILoginService
    {
        BaseResponse LogIn(LogInRequest request);
    }
}
