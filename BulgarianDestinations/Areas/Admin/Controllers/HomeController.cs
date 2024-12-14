using Microsoft.AspNetCore.Mvc;

namespace BulgarianDestinations.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
