using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Models.Region;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using System.Security.Claims;
using static BulgarianDestinations.Core.Constants.RoleConstants;

namespace BulgarianDestinations.Controllers
{
    public class RegionController: BaseController
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
            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            var model = await regionService.All();
            return View(model);
        }

        [Area("Admin")]
        [Authorize(Roles = AdminRole)]
        [HttpGet]
        public async Task<IActionResult> DetailsAdmin(int regionId)
        {
            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            if (await regionService.Exists(regionId) == false)
            {
                return BadRequest();
            }
            var model = await regionService.GetAll(regionId);
            return View(model);
        }

    }
}
