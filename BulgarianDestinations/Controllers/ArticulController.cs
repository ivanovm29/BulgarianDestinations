using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Models.Articul;
using BulgarianDestinations.Core.Models.Destination;
using BulgarianDestinations.Core.Services;
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

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new ArticulFormViewModel();
            return View(model);
        }

        public async Task<IActionResult> Add(ArticulFormViewModel model)
        {
            await articulService.AddArticul(model);

            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            await articulService.DeleteArticul(id);

            return RedirectToAction("Index", "Home");
        }

    }
}
