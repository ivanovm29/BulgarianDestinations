using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Infrastructure.Data.Common;
using BulgarianDestinations.Infrastructure.Data.Models;
using BulgarianDestinations.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulgarianDestinations.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace BulgarianDestinations.Tests.ArticulTests
{
    [TestFixture]
    public class GetArticulTest
    {
        private IEnumerable<Articul> articuls;
        private IEnumerable<Person> persons;
        private IEnumerable<ArticulPerson> articulsPersons;
        private ApplicationDbContext dbContext;
        private IRepository repository;
        IArticulService service;
        [SetUp]
        public void TestInitialize()
        {
            articuls = new List<Articul>()
            {
                new Articul(){Id = 1, Name = "Motika", Description = "Some motika.", ImageUrl = "https://i.ibb.co/0Dmhdz1/grivna.jpg", Price = 10.25M},
                new Articul(){Id = 2, Name = "Binokal", Description = "Some binokal.", ImageUrl = "https://i.ibb.co/q5K7mh6/rakavici.jpg", Price = 9.30M},
                new Articul(){Id = 3, Name = "Kniga", Description = "Some kniga.", ImageUrl = "https://i.ibb.co/BqBxQxB/pompa.jpg", Price = 28.00M},

            };
            persons = new List<Person>()
            {
                new Person(){Id = 1, UserId = "5f378b69-c6a2-48a4-8ead-fe56eccfa3e1"},
                new Person(){Id = 2,UserId = "4039ebe6-607a-4436-9494-9272e556d30a"}
            };
            articulsPersons = new List<ArticulPerson>();
            //{
            //    new ArticulPerson(){ArticulId = 1, PersonId = 1},
            //    new ArticulPerson(){ArticulId = 2, PersonId = 1},
            //    new ArticulPerson(){ArticulId = 2, PersonId = 2},
            //    new ArticulPerson(){ArticulId = 3, PersonId = 2}
            //};


            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "GetArticlulInMemoryDb") // Give a Unique name to the DB
                    .Options;
            dbContext = new ApplicationDbContext(options);
            dbContext.AddRange(articuls);
            dbContext.AddRange(persons);
            dbContext.AddRange(articulsPersons);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);
            service = new ArticulService(repository); // Pass it to Service as dependency
        }

        [Test]
        public void Test_GetArticul()
        {
            service.GetArticul(1, 1);
            service.GetArticul(2, 1);
            service.GetArticul(2, 2);

            var count = 3;
            var expxtedCount = repository.AllReadOnly<ArticulPerson>().Count();

            Assert.That(count, Is.EqualTo(expxtedCount));
        }
    }
}
