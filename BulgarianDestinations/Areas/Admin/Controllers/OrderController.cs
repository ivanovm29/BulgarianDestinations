using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Services;
using BulgarianDestinations.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BulgarianDestinations.Core.Constants.RoleConstants;

namespace BulgarianDestinations.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdminRole)]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(
            IOrderService _orderService)
        {
            orderService = _orderService;
        }
        [HttpGet]
        public IActionResult All()
        {
            var model = orderService.All();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await orderService.Exists(id) == false)
            {
                return BadRequest();
            }
            var model = await orderService.OrderInformation(id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await orderService.Exists(id) == false)
            {
                return BadRequest();
            }

            await orderService.DeleteOrder(id);

            return RedirectToAction("Index", "Home");

        }
    }
}
