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
    public class ReturnArticulInformation
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
                new Articul(){Id = 2, Name = "Binokal", Description = "Some binokal.", ImageUrl = "https://i.ibb.co/q5K7mh6/rakavici.jpg", Price = 9.30M},
                new Articul(){Id = 3, Name = "Kniga", Description = "Some kniga.", ImageUrl = "https://i.ibb.co/BqBxQxB/pompa.jpg", Price = 28.00M},

            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "ArticlulDetailsInMemoryDb") // Give a Unique name to the DB
                    .Options;
            dbContext = new ApplicationDbContext(options);
            dbContext.AddRange(articuls);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);
            service = new ArticulService(repository); // Pass it to Service as dependency
        }

        [Test]
        public void Test_GetArticulInformation()
        {
            int id = 2;

            var articul = service.ArticulInformation(id);

            var articulName = articul.Result.Name;
            var articulDescription = articul.Result.Description;
            var articulImageUrl = articul.Result.ImageUrl;
            var articulPrice = articul.Result.Price;

            var articulNameExpected = articuls.FirstOrDefault(a => a.Id == id).Name;
            var articulDescriptionExpected = articuls.FirstOrDefault(a => a.Id == id).Description;
            var articulImageUrlExpected = articuls.FirstOrDefault(a => a.Id == id).ImageUrl;
            var articulPriceExpected = articuls.FirstOrDefault(a => a.Id == id).Price;

            Assert.That(articulName, Is.EqualTo(articulNameExpected));
            Assert.That(articulDescription, Is.EqualTo(articulDescriptionExpected));
            Assert.That(articulImageUrl, Is.EqualTo(articulImageUrlExpected));
            Assert.That(articulPrice, Is.EqualTo(articulPriceExpected));

        }
    }
}
