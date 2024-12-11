using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulgarianDestinations.Controllers
{
    public class ArticulController : Controller
    {
        private readonly IArticulService articulService;

        public ArticulController(
            IArticulService _articulService)
        {
            articulService = _articulService;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await articulService.All();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await articulService.ArticulInformation(id);
            return View(model);
        }

        public async Task<IActionResult> Get(int articulId, int personId)
        {
            await articulService.GetArticul(articulId, personId);
            return RedirectToAction("All");
        }

    }
}
