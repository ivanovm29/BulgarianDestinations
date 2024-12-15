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

namespace BulgarianDestinations.Tests.ArticulTests
{
    [TestFixture]
    public class ExistsArticulTest
    {
        private IEnumerable<Articul> articuls;
        private ApplicationDbContext dbContext;
        private IRepository repository;
        IArticulService service;
        [SetUp]
        public void TestInitialize()
        {
            articuls = new List<Articul>()
            {
                new Articul(){Id = 1, Name = "Motika", Description = "Some motika.", ImageUrl = "https://i.ibb.co/0Dmhdz1/grivna.jpg", Price = 10.25M},
                new Articul(){Id = 2, Name = "Kniga", Description = "Some kniga.", ImageUrl = "https://i.ibb.co/BqBxQxB/pompa.jpg", Price = 28.00M},

            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "ExistsArticlulInMemoryDb") // Give a Unique name to the DB
                    .Options;
            dbContext = new ApplicationDbContext(options);
            dbContext.AddRange(articuls);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);
            service = new ArticulService(repository); // Pass it to Service as dependency
        }

        [Test]
        public void Test_DeleteArticul()
        {
            bool actualTrue = service.Exists(2).Result;
            var actualFalse = service.Exists(3).Result;

            Assert.That(actualTrue , Is.EqualTo(true));
            Assert.That(actualFalse, Is.EqualTo(false));
        }
    }
}
