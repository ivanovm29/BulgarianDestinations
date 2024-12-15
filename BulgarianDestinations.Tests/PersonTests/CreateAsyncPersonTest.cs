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
using BulgarianDestinations.Core.Contracts;

namespace BulgarianDestinations.Tests.PersonTests
{
    [TestFixture]
    public class CreateAsyncPersonTest
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

            users = new ApplicationUser[] { user1};

            persons = new List<Person>();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "CreateAsyncPersonTestInMemoryDb") // Give a Unique name to the DB
                    .Options;
            dbContext = new ApplicationDbContext(options);
            dbContext.AddRange(users);
            dbContext.AddRange(persons);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);
            service = new PersonService(repository); // Pass it to Service as dependency
        }

        [Test]
        public void Test_CreateAsyncPersonTest()
        {
            string userId = "5f378b69-c6a2-48a4-8ead-fe56eccfa3e1";
            service.CreateAsync(userId);

            var allPersons = repository.AllReadOnly<Person>();

            int actualCount = allPersons.Count();
            string actualUserId = allPersons.FirstOrDefault(p => p.Id == 1).UserId;

            int expectedCount = 1;
            string expectedUserId = "5f378b69-c6a2-48a4-8ead-fe56eccfa3e1";


            Assert.That(actualCount, Is.EqualTo(expectedCount));
            Assert.That(actualUserId, Is.EqualTo(expectedUserId));
        }
    }
}
