using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Services;
using BulgarianDestinations.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulgarianDestinations.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartServices cartService;

        public CartController(
            ICartServices _cartService)
        {
            cartService = _cartService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await cartService.All();
            return View(model);
        }

        public async Task<IActionResult> Remove(int articulId, int personId)
        {
            await cartService.RemoveArticul(articulId, personId);
            return RedirectToAction("All", new { personid = personId });
        }

        public async Task<IActionResult> Order(int personId)
        {
            await cartService.OrderArticuls(personId);
            return RedirectToAction("Index", "Home");
        }
    }
}
