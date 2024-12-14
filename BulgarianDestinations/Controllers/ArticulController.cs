using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Models.Articul;
using BulgarianDestinations.Core.Models.Destination;
using BulgarianDestinations.Core.Services;
using BulgarianDestinations.Infrastructure.Data.Common;
using BulgarianDestinations.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BulgarianDestinations.Controllers
{
    public class ArticulController : Controller
    {
        private readonly IArticulService articulService;
        private readonly IRepository repository;

        public ArticulController(
            IArticulService _articulService,
            IRepository _repository)
        {
            articulService = _articulService;
            repository = _repository;
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

        public async Task<IActionResult> Get(int articulId)
        {
            await articulService.GetArticul(articulId, GetUserId());
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

        public int GetUserId()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;

            var person = repository.AllReadOnly<Person>()
                .Where(p => p.UserId == userId)
                .FirstOrDefault();

            return person.Id;
        }

    }
}
