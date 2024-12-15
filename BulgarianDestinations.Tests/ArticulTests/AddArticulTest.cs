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
using BulgarianDestinations.Core.Models.Articul;

namespace BulgarianDestinations.Tests.ArticulTests
{
    [TestFixture]
    public class AddArticulTest
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
                    .UseInMemoryDatabase(databaseName: "AddArticlulInMemoryDb") // Give a Unique name to the DB
                    .Options;
            dbContext = new ApplicationDbContext(options);
            dbContext.AddRange(articuls);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);
            service = new ArticulService(repository); // Pass it to Service as dependency
        }
        [Test]
        public void Test_AddArticul()
        {
            var articul = new ArticulFormViewModel()
            {
                Name = "Bradva",
                Description = "Some Bradva",
                ImageUrl = "https://i.ibb.co/q5K7mh6/rakavici.jpg",
                Price = 11.50M,
            };

            service.AddArticul(articul);

            var count = 3;
            var expxtedCount = repository.AllReadOnly<Articul>().Count();

            var name = articul.Name;
            var description = articul.Description;
            var imageUrl = articul.ImageUrl;
            var price = articul.Price;

            var expectedName = repository.GetById<Articul>(3).Result.Name;
            var expectedDescription = repository.GetById<Articul>(3).Result.Description;
            var expectedImageUrl = repository.GetById<Articul>(3).Result.ImageUrl;
            var expectedPrice = repository.GetById<Articul>(3).Result.Price;

            Assert.That(count, Is.EqualTo(expxtedCount));

            Assert.That(name, Is.EqualTo(expectedName));
            Assert.That(description, Is.EqualTo(expectedDescription));
            Assert.That(imageUrl, Is.EqualTo(expectedImageUrl));
            Assert.That(price, Is.EqualTo(expectedPrice));

        }
    }
}
