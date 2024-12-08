using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BulgarianDestinations.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService destinationService;

        public DestinationController(
            IDestinationService _destinationService)
        {
            destinationService = _destinationService;
        }
        public async Task<IActionResult> Details(int id)
        {
            var model = await destinationService.DestinationInformation(id);
            return View(model);
        }
    }
}
