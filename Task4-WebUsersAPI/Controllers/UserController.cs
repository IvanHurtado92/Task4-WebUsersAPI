using Microsoft.AspNetCore.Mvc;

namespace Task4_WebUsersAPI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
