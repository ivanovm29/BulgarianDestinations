using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Models.Articul;
using BulgarianDestinations.Core.Models.Destination;
using BulgarianDestinations.Core.Services;
using BulgarianDestinations.Infrastructure.Data.Common;
using BulgarianDestinations.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static BulgarianDestinations.Core.Constants.RoleConstants;

namespace BulgarianDestinations.Controllers
{
    public class ArticulController : BaseController
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

        [Area("Admin")]
        [Authorize(Roles = AdminRole)]
        [HttpGet]
        public async Task<IActionResult> AllAdmin()
        {
            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            var model = await articulService.All();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if(await articulService.Exists(id) == false)
            {
                return BadRequest();
            }

            var model = await articulService.ArticulInformation(id);
            return View(model);
        }

        [Area("Admin")]
        [Authorize(Roles = AdminRole)]
        [HttpGet]
        public async Task<IActionResult> DetailsAdmin(int id)
        {
            if (await articulService.Exists(id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            var model = await articulService.ArticulInformation(id);
            return View(model);
        }

        public async Task<IActionResult> Get(int articulId)
        {
            if (await articulService.Exists(articulId) == false)
            {
                return BadRequest();
            }
            await articulService.GetArticul(articulId, GetUserId());
            return RedirectToAction("All");
        }
        [Area("Admin")]
        [Authorize(Roles = AdminRole)]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            var model = new ArticulFormViewModel();
            return View(model);
        }

        [Area("Admin")]
        [Authorize(Roles = AdminRole)]
        public async Task<IActionResult> Add(ArticulFormViewModel model)
        {
            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            await articulService.AddArticul(model);

            return RedirectToAction("AllAdmin", "Articul");

        }
        [Area("Admin")]
        [Authorize(Roles = AdminRole)]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await articulService.Exists(id) == false)
            {
                return BadRequest();
            }

            if(User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            await articulService.DeleteArticul(id);

            return RedirectToAction("AllAdmin", "Articul");
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
