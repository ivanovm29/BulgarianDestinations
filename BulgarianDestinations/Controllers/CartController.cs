using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Services;
using BulgarianDestinations.Infrastructure.Data.Common;
using BulgarianDestinations.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BulgarianDestinations.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartServices cartService;
        private readonly IRepository repository;

        public CartController(
            ICartServices _cartService,
            IRepository _repository)
        {
            cartService = _cartService;
            repository = _repository;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await cartService.All();
            return View(model);
        }

        public async Task<IActionResult> Remove(int articulId)
        {
            await cartService.RemoveArticul(articulId, GetUserId());
            return RedirectToAction("All", new { personid = GetUserId() });
        }

        public async Task<IActionResult> Order()
        {
            await cartService.OrderArticuls(GetUserId());
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
