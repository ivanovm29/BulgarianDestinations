using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Services;
using BulgarianDestinations.Infrastructure.Data.Common;
using BulgarianDestinations.Infrastructure.Data.Models;
using BulgarianDestinations.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Tests.PersonTests
{
    [TestFixture]
    public class GetDestinationTest
    {
        private IEnumerable<Destination> destinations;
        private IEnumerable<DestinationPerson> destinationsPersons;
        private IEnumerable<Region> regions;
        private IEnumerable<Person> persons;
        private IEnumerable<ApplicationUser> users;
        private ApplicationDbContext dbContext;
        private IRepository repository;
        IPersonService personService;
        IDestinationService service;

        [SetUp]
        public void TestInitialize()
        {

            var person1 = new Person() { Id = 1, UserId = "5f378b69-c6a2-48a4-8ead-fe56eccfa3e1" };
            var person2 = new Person() { Id = 2, UserId = "4039ebe6-607a-4436-9494-9272e556d30a" };

            var user1 = new ApplicationUser() { Id = "5f378b69-c6a2-48a4-8ead-fe56eccfa3e1", FirstName = "Marian", LastName = "Ivanov", UserName = "ivanov.m29@abv.bg" };
            var user2 = new ApplicationUser() { Id = "4039ebe6-607a-4436-9494-9272e556d30a", FirstName = "Georgi", LastName = "Georgiev", UserName = "georgi.m29@abv.bg" };

            users = new ApplicationUser[] { user1, user2 };

            persons = new List<Person>()
            {
                person1,
                person2
            };

            var destination1 = new Destination()
            {
                Id = 1,
                Name = "Рупите - Къщата на Ванга",
                Description = "Къщата на Баба Ванга в местността Рупите е била мястото, където известната българска пророчица е приемала нуждаещите се.",
                ImageUrl = "https://i.ibb.co/Q6wvBfd/rupite.jpg",
                RegionId = 1,
            };
            var destination2 = new Destination()
            {
                Id = 2,
                Name = "Мелник",
                Description = "яж е уяжшеу жш Мелник аяио жго ",
                ImageUrl = "https://i.ibb.co/Q6wvBfd/rupite.jpg",
                RegionId = 1,
            };
            var region = new Region()
            {
                Id = 1,
                Name = "Благоевград",
                Destinations = new List<Destination>() { destination1, destination2 }
            };

            destinations = new List<Destination>()
            {
                destination1, destination2
            };
            regions = new List<Region>() { region };

            destinationsPersons = new List<DestinationPerson>();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "GetDestinationTestInMemoryDb") // Give a Unique name to the DB
                    .Options;
            dbContext = new ApplicationDbContext(options);
            dbContext.AddRange(users);
            dbContext.AddRange(persons);
            dbContext.AddRange(destinations);
            dbContext.AddRange(regions);
            dbContext.AddRange(destinationsPersons);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);
            service = new DestinationService(repository); // Pass it to Service as dependency
            personService = new PersonService(repository);
        }

        [Test]
        public void Test_GetDestinationTest()
        {
            personService.GetDestination(1, 1);

            int actualCount = repository.AllReadOnly<DestinationPerson>().Count();
            int actualDestinationId = repository.AllReadOnly<DestinationPerson>().FirstOrDefault(a => a.PersonId == 1).DestinationId;
            int actualPersonId = repository.AllReadOnly<DestinationPerson>().FirstOrDefault(a => a.DestinationId == 1).PersonId;

            int expectedCount = 1;
            int expectedDestinationId = 1;
            int expectedPersonId = 1;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
            Assert.That(actualDestinationId, Is.EqualTo(expectedDestinationId));
            Assert.That(actualPersonId, Is.EqualTo(expectedPersonId));

        }
    }
}
