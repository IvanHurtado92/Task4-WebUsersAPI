using Task4_WebUsersAPI.DTOs;
using Task4_WebUsersAPI.DTOs.Login;
using Task4_WebUsersAPI.Models;
using System.Net;

namespace Task4_WebUsersAPI.Services
{
    public class LogInService : ILoginService
    {
        private readonly UserDbContext _context;

        public LogInService(UserDbContext context) 
        { 
            _context = context;
        }

        public BaseResponse LogIn(LogInRequest data)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == data.Email && u.Password == data.Password);
            if (user == null)
            {
                return new BaseResponse(HttpStatusCode.Unauthorized, "No user found with that credentials");
            }
            try
            {
                if (user.Blocked == true)
                {
                    return new BaseResponse(HttpStatusCode.Unauthorized, "User blocked");
                }
                user.Last_Connection = DateTime.Now;
                _context.SaveChanges();
                return new BaseResponse(HttpStatusCode.OK, $"{data.Email} found, access granted");
            }
            catch (Exception ex) 
            {
                return new BaseResponse(HttpStatusCode.InternalServerError, BaseResponse.DataBaseExceptionMessage(ex));
            }
        }
    }
}
