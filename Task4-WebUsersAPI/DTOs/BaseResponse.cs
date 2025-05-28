using System.Net;

namespace Task4_WebUsersAPI.DTOs
{
    public class BaseResponse
    {
        public int status {  get; set; }
        public object? data { get; set; }

        public BaseResponse(HttpStatusCode statusCode, object? data) // Constructor
        {
            this.status = (int)statusCode;
            this.data = data;
        }

        public static string DataBaseExceptionMessage(Exception e)
        {
            return e.InnerException != null ? e.InnerException.Message : e.Message;
        }
    }
}
