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

namespace BulgarianDestinations.Tests.CartTests
{
    [TestFixture]
    public class TotalPriceInCartTest
    {
        private IEnumerable<Articul> articuls;
        private IEnumerable<Person> persons;
        private IEnumerable<ArticulPerson> articulsPersons;
        private ApplicationDbContext dbContext;
        private IRepository repository;
        ICartServices service;
        [SetUp]
        public void TestInitialize()
        {
            var articul1 = new Articul() { Id = 1, Name = "Motika", Description = "Some motika.", ImageUrl = "https://i.ibb.co/0Dmhdz1/grivna.jpg", Price = 10.25M };
            var articul2 = new Articul() { Id = 2, Name = "Binokal", Description = "Some binokal.", ImageUrl = "https://i.ibb.co/q5K7mh6/rakavici.jpg", Price = 9.30M };
            var articul3 = new Articul() { Id = 3, Name = "Kniga", Description = "Some kniga.", ImageUrl = "https://i.ibb.co/BqBxQxB/pompa.jpg", Price = 28.00M, };

            var person1 = new Person() { Id = 1, UserId = "5f378b69-c6a2-48a4-8ead-fe56eccfa3e1" };
            var person2 = new Person() { Id = 2, UserId = "4039ebe6-607a-4436-9494-9272e556d30a" };

            articuls = new List<Articul>()
            {
                articul1,
                articul2,
                articul3,

            };

            persons = new List<Person>()
            {
                person1,
                person2
            };
            articulsPersons = new List<ArticulPerson>()
            {
                new ArticulPerson(){ArticulId = 1, PersonId = 1, Articul = articul1, Person = person1 },
                new ArticulPerson(){ArticulId = 2, PersonId = 1, Articul = articul2, Person = person1},
                new ArticulPerson(){ArticulId = 2, PersonId = 2, Articul = articul2, Person = person2},
                new ArticulPerson(){ArticulId = 3, PersonId = 2 , Articul = articul3, Person = person2}
            };


            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "TotalPriceInCartInMemoryDb") // Give a Unique name to the DB
                    .Options;
            dbContext = new ApplicationDbContext(options);
            dbContext.AddRange(articuls);
            dbContext.AddRange(persons);
            dbContext.AddRange(articulsPersons);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);
            service = new CartServices(repository); // Pass it to Service as dependency
        }

        [Test]
        public void Test_TotalPriceInCart()
        {
            decimal actualTotalPrice = service.TotalPrice(1).Result;
            decimal expectedTotalPrice = 19.55M;


            Assert.That(actualTotalPrice, Is.EqualTo(expectedTotalPrice));
        }
    }
}
