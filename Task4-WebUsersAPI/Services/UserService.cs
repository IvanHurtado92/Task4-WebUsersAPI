using Task4_WebUsersAPI.DTOs;
using Task4_WebUsersAPI.Models;
using System.Net;
using Task4_WebUsersAPI.DTOs.User;

namespace Task4_WebUsersAPI.Services
{
    public class UserService : IUserService
    {
        private readonly UserDbContext _context;

        public UserService(UserDbContext context)
        {
            _context = context;
        }

        public BaseResponse CreateUser(CreateUserRequest DTOuser)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == DTOuser.Email);
            if (existingUser != null) 
            {
                return new BaseResponse(HttpStatusCode.BadRequest, "Email already exists");
            }
            else
            {
                try
                {
                    User user = new User
                    {
                        Name = DTOuser.Name,
                        Email = DTOuser.Email,
                        Password = DTOuser.Password,
                        Blocked = false
                    };

                    _context.Users.Add(user);
                    _context.SaveChanges();

                    return new BaseResponse(HttpStatusCode.OK, "User creation successful");
                }
                catch (Exception ex)
                {
                    return new BaseResponse(HttpStatusCode.InternalServerError, BaseResponse.DataBaseExceptionMessage(ex));
                }
            }
        }
        public BaseResponse GetUsers()
        {
            try
            {
                var users = _context.Users.Select(p =>
                new
                {
                    p.Name,
                    p.Email,
                    p.Blocked,
                    p.Last_Connection,
                }).ToList();
                return new BaseResponse(HttpStatusCode.OK, users);
            }
            catch (Exception ex)
            {
                return new BaseResponse(HttpStatusCode.InternalServerError, BaseResponse.DataBaseExceptionMessage(ex));
            }
        }

        public BaseResponse DeleteUser(int UserId) 
        {
            try
            {
                var user = _context.Users.Find(UserId);
                if (user == null)
                {
                    return new BaseResponse(HttpStatusCode.NotFound, "User not found");
                }

                _context.Users.Remove(user);
                _context.SaveChanges();

                return new BaseResponse(HttpStatusCode.OK, "User deleted successfully");
            }
            catch (Exception ex)
            {
                return new BaseResponse(HttpStatusCode.InternalServerError, BaseResponse.DataBaseExceptionMessage(ex));
            }
        }

        public BaseResponse BlockUser(int UserId)
        {
            try
            {
                var user = _context.Users.Find(UserId);
                if (user == null)
                {
                    return new BaseResponse(HttpStatusCode.NotFound, "User not found");
                }

                if(user.Blocked == false) user.Blocked = true;
                _context.SaveChanges();

                return new BaseResponse(HttpStatusCode.OK, "User deleted successfully");
            }
            catch (Exception ex)
            {
                return new BaseResponse(HttpStatusCode.InternalServerError, BaseResponse.DataBaseExceptionMessage(ex));
            }
        }

        public BaseResponse UnblockUser(int UserId)
        {
            try
            {
                var user = _context.Users.Find(UserId);
                if (user == null)
                {
                    return new BaseResponse(HttpStatusCode.NotFound, "User not found");
                }

                if (user.Blocked == true) user.Blocked = false;
                _context.SaveChanges();

                return new BaseResponse(HttpStatusCode.OK, "User deleted successfully");
            }
            catch (Exception ex)
            {
                return new BaseResponse(HttpStatusCode.InternalServerError, BaseResponse.DataBaseExceptionMessage(ex));
            }
        }
    }
}
