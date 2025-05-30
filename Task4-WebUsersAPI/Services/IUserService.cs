using Task4_WebUsersAPI.DTOs;
using Task4_WebUsersAPI.DTOs.ForgoPassword;
using Task4_WebUsersAPI.DTOs.User;

namespace Task4_WebUsersAPI.Services
{
    public interface IUserService
    {
        BaseResponse CreateUser(CreateUserRequest request);
        BaseResponse GetUsers();
        BaseResponse DeleteUser(int[] usersId);
        BaseResponse BlockUser(int[]  usersId);
        BaseResponse UnblockUser(int[] usersId);
        BaseResponse IsUserBlocked(ForgotPasswordRequest request);
        BaseResponse GetPassword(ForgotPasswordRequest request);
    }
}
