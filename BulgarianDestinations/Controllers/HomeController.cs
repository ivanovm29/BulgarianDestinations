using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Services;
using BulgarianDestinations.Infrastructure.Data.Models;
using BulgarianDestinations.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BulgarianDestinations.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRegionService regionService;

        public HomeController(ILogger<HomeController> logger, IRegionService _regionService)
        {
            _logger = logger;
            regionService = _regionService;
        }
        [AllowAnonymous]
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
            if (await regionService.Exists(regionId) == false)
            {
                return BadRequest();
            }

            var model = await regionService.GetAll(regionId);
            return View(model);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if(statusCode == 400)
            {
                return View("Error400");
            }
            if(statusCode == 401)
            {
                return View("Error401");
            }

            return View("Error");
        }
    }
}
