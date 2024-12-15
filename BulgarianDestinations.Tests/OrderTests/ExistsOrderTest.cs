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

namespace BulgarianDestinations.Tests.OrderTests
{
    [TestFixture]
    public class ExistsOrderTest
    {
        private IEnumerable<Articul> articuls;
        private IEnumerable<Order> orders;
        private IEnumerable<Person> persons;
        private IEnumerable<ApplicationUser> users;
        private ApplicationDbContext dbContext;
        private IRepository repository;
        IOrderService service;

        [SetUp]
        public void TestInitialize()
        {

            var person1 = new Person() { Id = 1, UserId = "5f378b69-c6a2-48a4-8ead-fe56eccfa3e1" };
            var person2 = new Person() { Id = 2, UserId = "4039ebe6-607a-4436-9494-9272e556d30a" };

            var user1 = new ApplicationUser() { Id = "5f378b69-c6a2-48a4-8ead-fe56eccfa3e1", FirstName = "Marian", LastName = "Ivanov", UserName = "ivanov.m29@abv.bg" };
            var user2 = new ApplicationUser() { Id = "4039ebe6-607a-4436-9494-9272e556d30a", FirstName = "Georgi", LastName = "Georgiev", UserName = "georgi.m29@abv.bg" };

            var articul1 = new Articul() { Id = 1, Name = "Motika", Description = "Some motika.", ImageUrl = "https://i.ibb.co/0Dmhdz1/grivna.jpg", Price = 10.25M };
            var articul2 = new Articul() { Id = 2, Name = "Binokal", Description = "Some binokal.", ImageUrl = "https://i.ibb.co/q5K7mh6/rakavici.jpg", Price = 9.30M };
            var articul3 = new Articul() { Id = 3, Name = "Kniga", Description = "Some kniga.", ImageUrl = "https://i.ibb.co/BqBxQxB/pompa.jpg", Price = 28.00M, };

            users = new ApplicationUser[] { user1, user2 };

            persons = new List<Person>()
            {
                person1,
                person2
            };
            articuls = new List<Articul>()
            {
                articul1,
                articul2,
                articul3,

            };

            var order1 = new Order()
            {
                Id = 1,
                Articuls = new List<Articul>() { articul1, articul2 },
                PersonId = 1,
                TotalPrice = 19.55M
            };
            var order2 = new Order()
            {
                Id = 2,
                Articuls = new List<Articul>() { articul3 },
                PersonId = 2,
                TotalPrice = 28.00M
            };

            orders = new List<Order>() { order1, order2 };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "ExistsOrderTestInMemoryDb") // Give a Unique name to the DB
                    .Options;
            dbContext = new ApplicationDbContext(options);
            dbContext.AddRange(users);
            dbContext.AddRange(persons);
            dbContext.AddRange(articuls);
            dbContext.AddRange(orders);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);
            service = new OrderService(repository); // Pass it to Service as dependency
        }

        [Test]
        public void Test_ExistsOrderTest()
        {

            bool actualTrue = service.Exists(2).Result;
            bool actualFalse = service.Exists(3).Result;

            Assert.That(actualTrue, Is.EqualTo(true));
            Assert.That(actualFalse, Is.EqualTo(false));
        }
    }
}
