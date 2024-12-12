using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Services;
using BulgarianDestinations.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BulgarianDestinations.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRegionService regionService;

        public HomeController(ILogger<HomeController> logger, IRegionService _regionService)
        {
            _logger = logger;
            regionService = _regionService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Map()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RegionDetails(int regionId)
        {
            var model = await regionService.GetAll(regionId);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
