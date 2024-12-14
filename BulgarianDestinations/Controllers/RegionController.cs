using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Models.Region;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using static BulgarianDestinations.Core.Constants.RoleConstants;

namespace BulgarianDestinations.Controllers
{
    public class RegionController: Controller
    {
        private readonly IRegionService regionService;

        public RegionController(
            IRegionService _regionService)
        {
            regionService = _regionService;
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

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await regionService.All();
            return View(model);
        }

        [Area("Admin")]
        [Authorize(Roles = AdminRole)]
        [HttpGet]
        public async Task<IActionResult> AllAdmin()
        {
            var model = await regionService.All();
            return View(model);
        }

        [Area("Admin")]
        [Authorize(Roles = AdminRole)]
        [HttpGet]
        public async Task<IActionResult> DetailsAdmin(int regionId)
        {
            if (await regionService.Exists(regionId) == false)
            {
                return BadRequest();
            }
            var model = await regionService.GetAll(regionId);
            return View(model);
        }

    }
}
