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
    public class ExistsByIdPersonTest
    {
        private IEnumerable<Person> persons;
        private IEnumerable<ApplicationUser> users;
        private ApplicationDbContext dbContext;
        private IRepository repository;
        IPersonService service;
        [SetUp]
        public void TestInitialize()
        {

            var user1 = new ApplicationUser() { Id = "5f378b69-c6a2-48a4-8ead-fe56eccfa3e1", FirstName = "Marian", LastName = "Ivanov", UserName = "ivanov.m29@abv.bg" };

            users = new ApplicationUser[] { user1 };

            persons = new List<Person>();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ExistsByIdPersonTestInMemoryDb") // Give a Unique name to the DB
                    .Options;
            dbContext = new ApplicationDbContext(options);
            dbContext.AddRange(users);
            dbContext.AddRange(persons);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);
            service = new PersonService(repository); // Pass it to Service as dependency
        }

        [Test]
        public void Test_ExistsByIdPersonTest()
        {
            string userId = "5f378b69-c6a2-48a4-8ead-fe56eccfa3e1";
            service.CreateAsync(userId);

            bool actualTrue = service.ExistsById("5f378b69-c6a2-48a4-8ead-fe56eccfa3e1").Result;
            bool actualFalse = service.ExistsById("sdggdb69-c6a2-48a4-8ead-fe56eccfa3e1").Result;


            Assert.That(actualTrue, Is.EqualTo(true));
            Assert.That(actualFalse, Is.EqualTo(false));
        }
    }
}
