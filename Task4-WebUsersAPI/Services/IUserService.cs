using Task4_WebUsersAPI.DTOs;
using Task4_WebUsersAPI.DTOs.ForgoPassword;
using Task4_WebUsersAPI.DTOs.User;

namespace Task4_WebUsersAPI.Services
{
    public interface IUserService
    {
        BaseResponse CreateUser(CreateUserRequest request);
        BaseResponse GetUsers();
        BaseResponse DeleteUser(int id);
        BaseResponse BlockUser(int  userId);
        BaseResponse UnblockUser(int userId);
        BaseResponse IsUserBlocked(int userId);
        BaseResponse GetPassword(ForgotPasswordRequest request);
    }
}
