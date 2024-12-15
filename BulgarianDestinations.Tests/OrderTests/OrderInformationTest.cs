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
    public class OrderInformationTest
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
                    .UseInMemoryDatabase(databaseName: "OrderInformationTestInMemoryDb") // Give a Unique name to the DB
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
        public void Test_OrderInformationTest()
        {
            var order = service.OrderInformation(1).Result;

            int actualOrderId = order.OrderId;
            int actualPersonId = order.PersonId;
            string actualFirstName = order.FirstName;
            string actualLastName = order.LastName;
            decimal actualTotalPrice = order.TotalPrice;
            int actualArticulsCount = order.Articuls.Count();

            int actualArticulId = order.Articuls[0].Id;
            string actualArticulName = order.Articuls[0].Name;
            string actualArticulDescription = order.Articuls[0].Description;
            string actualArticulImageUrl = order.Articuls[0].ImageUrl;
            decimal actualArticulPrice = order.Articuls[0].Price;


            int orderId = 1;
            int personId = 1;
            string firstName = "Marian";
            string lastName = "Ivanov";
            decimal totalPrice = 19.55M;
            int articulsCount = 2;

            int articulId = 1;
            string articulName = "Motika";
            string articulDescription = "Some motika.";
            string articulImageUrl = "https://i.ibb.co/0Dmhdz1/grivna.jpg";
            decimal articulPrice = 10.25M;

            
            Assert.That(actualOrderId, Is.EqualTo(orderId));
            Assert.That(actualPersonId, Is.EqualTo(personId));
            Assert.That(actualFirstName, Is.EqualTo(firstName));
            Assert.That(actualLastName, Is.EqualTo(lastName));
            Assert.That(actualTotalPrice, Is.EqualTo(totalPrice));
            Assert.That(actualArticulsCount, Is.EqualTo(articulsCount));

            Assert.That(actualArticulId, Is.EqualTo(articulId));
            Assert.That(actualArticulName, Is.EqualTo(articulName));
            Assert.That(actualArticulDescription, Is.EqualTo(articulDescription));
            Assert.That(actualArticulImageUrl, Is.EqualTo(articulImageUrl));
            Assert.That(actualArticulPrice, Is.EqualTo(articulPrice));

        }
    }
}
