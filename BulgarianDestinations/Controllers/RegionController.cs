using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Models.Region;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

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

        public async Task<IActionResult> RegionDetails(int regionId)
        {
            var model = await regionService.GetAll(regionId);
            return View(model);
        }
        
    }
}
