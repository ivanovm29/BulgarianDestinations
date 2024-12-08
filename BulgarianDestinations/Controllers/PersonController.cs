using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulgarianDestinations.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService personService;

        public PersonController(IPersonService _personService)
        {
            personService = _personService;
        }
    }
}
