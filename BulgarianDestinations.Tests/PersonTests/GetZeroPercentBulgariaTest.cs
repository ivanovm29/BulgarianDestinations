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
    public class GetZeroPercentBulgarianTest
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
            var destination3 = new Destination()
            {
                Id = 3,
                Name = "Добърско - вкопаната църква",
                Description = "Късносредновековната църква „Св. св. Теодор Тирон и Теодор Стратилат“",
                ImageUrl = "https://i.ibb.co/LkYVK96/Dobursko.jpg",
                RegionId = 1,
            };
            var destination4 = new Destination()
            {
                Id = 4,
                Name = "Плажът на Иракли",
                Description = "Плажната ивица на Иракли е дълга и широка. От към входа, пясъкът е ситен и жълт.",
                ImageUrl = "https://i.ibb.co/rMX0M7n/Irakli.jpg",
                RegionId = 2
            };
            var destination5 = new Destination()
            {
                Id = 5,
                Name = "Несебър - стар град",
                Description = "Едва ли са много хората, които са посетили Стария град на Несебър и той не е станал любимо място за разходка и отдих.",
                ImageUrl = "https://i.ibb.co/BLfw4dh/Nesebar.jpg",
                RegionId = 2
            };

            var region1 = new Region()
            {
                Id = 1,
                Name = "Благоевград",
                Destinations = new List<Destination>() { destination1, destination2, destination3 }
            };
            var region2 = new Region()
            {
                Id = 2,
                Name = "Бургас",
                Destinations = new List<Destination>() { destination4, destination5 }
            };

            destinations = new List<Destination>()
            {
                destination1, destination2, destination3, destination4, destination5
            };
            regions = new List<Region>() { region1, region2 };

            destinationsPersons = new List<DestinationPerson>();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "GetZeroPercentBulgarianTestInMemoryDb") // Give a Unique name to the DB
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
        public void Test_GetZeroPercentBulgarianTest()
        {

            int actualPercent = personService.GetPercentBulgaria(1).Result;
            int expectedPercent = 0;

            Assert.That(actualPercent, Is.EqualTo(expectedPercent));

        }
    }
}
