using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Models.Destination;
using BulgarianDestinations.Infrastructure.Data.Common;
using BulgarianDestinations.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BulgarianDestinations.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService destinationService;
        private readonly IPersonService personService;
        private readonly IRegionService regionService;
        private readonly IRepository repository;

        public DestinationController(
            IDestinationService _destinationService,
            IPersonService _personService, 
            IRepository _repository,
            IRegionService _regionService)
        {
            destinationService = _destinationService;
            personService = _personService;
            repository = _repository;
            regionService = _regionService;
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await destinationService.DestinationInformation(id);
            return View(model);
        }

        public async Task<IActionResult> Join(int destinationId)
        {
            await personService.GetDestination(destinationId, GetUserId());
            return RedirectToAction("Details", new { id = destinationId });
        }

        public async Task<IActionResult> Leave(int destinationId)
        {
            await personService.GetOutDestination(destinationId, GetUserId());
            return RedirectToAction("Details", new { id = destinationId });
        }
        public int GetUserId()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;

            var person = repository.AllReadOnly<Person>()
                .Where(p => p.UserId == userId)
                .FirstOrDefault();

            return person.Id;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery]AllDestinationsQueryModel query)
        {
            var model = await destinationService.SearchAsync(
                query.Region,
                query.SearchTerm,
                query.CurrentPage,
                query.DestinationsPerPage
                );
            query.TotalDestinationsCount = model.TotalDestinationsCount;
            query.Destinations = model.Destinations;
            query.Regions = await destinationService.AllRegionsNameAsync();

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new DestinationFormViewModel();
            model.Regions = await regionService.GetCategories();
            return View(model);
        }

        public async Task<IActionResult> Add(DestinationFormViewModel model)
        {
            await destinationService.AddDestination(model);

            return RedirectToAction("Index", "Home");

        }
    }
}
