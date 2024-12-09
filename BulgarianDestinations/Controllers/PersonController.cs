using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Infrastructure.Data.Common;
using BulgarianDestinations.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BulgarianDestinations.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService personService;
        private readonly IRepository repository;

        public PersonController(IPersonService _personService, IRepository _repository)
        {
            personService = _personService;
            repository = _repository;
        }


    }
}
