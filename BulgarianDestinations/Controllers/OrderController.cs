using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BulgarianDestinations.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(
            IOrderService _orderService)
        {
            orderService = _orderService;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await orderService.All();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await orderService.OrderInformation(id);
            return View(model);
        }


    }
}
