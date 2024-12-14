using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BulgarianDestinations.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            return View();
        }
    }
}
