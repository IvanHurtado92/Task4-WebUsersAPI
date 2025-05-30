using Task4_WebUsersAPI.DTOs;
using Task4_WebUsersAPI.Models;
using System.Net;
using Task4_WebUsersAPI.DTOs.User;
using Task4_WebUsersAPI.DTOs.ForgoPassword;

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
            // Manual occupied Email verifying

            //var existingUser = _context.Users.FirstOrDefault(u => u.Email == DTOuser.Email);
            //if (existingUser != null) 
            //{
            //    return new BaseResponse(HttpStatusCode.BadRequest, "Email already exists");
            //}
            //else
            //{
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
            //}
        }
        public BaseResponse GetUsers()
        {
            try
            {
                var users = _context.Users.Select(p =>
                new
                {
                    p.IdUser,
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

        public BaseResponse DeleteUser(int[] UsersId) 
        {
            try
            {
                foreach (int i in UsersId) 
                { 
                    var user = _context.Users.Find(i);
                    if (user == null)
                    {
                        return new BaseResponse(HttpStatusCode.NotFound, $"User {i} not found");
                    }

                    _context.Users.Remove(user);
                }
                _context.SaveChanges();

                return new BaseResponse(HttpStatusCode.OK, "User/s deleted successfully");
            }
            catch (Exception ex)
            {
                return new BaseResponse(HttpStatusCode.InternalServerError, BaseResponse.DataBaseExceptionMessage(ex));
            }
        }

        public BaseResponse BlockUser(int[] UsersId)
        {
            try
            {
                foreach(int i in UsersId)
                {
                    var user = _context.Users.Find(i);
                    if (user == null)
                    {
                        return new BaseResponse(HttpStatusCode.NotFound, $"User {i} not found");
                    }
                    if(user.Blocked == false) user.Blocked = true;
                }

                _context.SaveChanges();

                return new BaseResponse(HttpStatusCode.OK, "User/s blocked successfully");
            }
            catch (Exception ex)
            {
                return new BaseResponse(HttpStatusCode.InternalServerError, BaseResponse.DataBaseExceptionMessage(ex));
            }
        }

        public BaseResponse UnblockUser(int[] UsersId)
        {
            try
            {
                foreach(int i in UsersId)
                {
                    var user = _context.Users.Find(i);
                    if (user == null)
                    {
                        return new BaseResponse(HttpStatusCode.NotFound, $"User {i} not found");
                    }
                    if(user.Blocked == true) user.Blocked = false;
                }

                _context.SaveChanges();

                return new BaseResponse(HttpStatusCode.OK, "User/s unblocked successfully");
            }
            catch (Exception ex)
            {
                return new BaseResponse(HttpStatusCode.InternalServerError, BaseResponse.DataBaseExceptionMessage(ex));
            }
        }

        public BaseResponse IsUserBlocked(ForgotPasswordRequest request)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == request.Email);
                if (user == null)
                {
                    return new BaseResponse(HttpStatusCode.NotFound, "User not found");
                }

                return new BaseResponse(HttpStatusCode.OK, user.Blocked);
            }
            catch (Exception ex)
            {
                return new BaseResponse(HttpStatusCode.InternalServerError, BaseResponse.DataBaseExceptionMessage(ex));
            }
        }

        public BaseResponse GetPassword(ForgotPasswordRequest request)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == request.Email);
                if (user == null)
                {
                    return new BaseResponse(HttpStatusCode.NotFound, "User not found");
                }
                return new BaseResponse(HttpStatusCode.OK, user.Password);
            }
            catch (Exception ex)
            {
                return new BaseResponse(HttpStatusCode.InternalServerError, BaseResponse.DataBaseExceptionMessage(ex));
            }
        }
    }
}
