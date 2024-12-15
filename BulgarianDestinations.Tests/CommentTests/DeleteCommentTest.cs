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
using BulgarianDestinations.Core.Models.Comment;

namespace BulgarianDestinations.Tests.CommentTests
{
    [TestFixture]
    public class DeleteCommentTest
    {
        private IEnumerable<Destination> destinations;
        private IEnumerable<Person> persons;
        private IEnumerable<Comment> comments;
        private IEnumerable<ApplicationUser> users;
        private ApplicationDbContext dbContext;
        private IRepository repository;
        ICommentService service;
        [SetUp]
        public void TestInitialize()
        {


            var destination1 = new Destination()
            {
                Id = 1,
                Name = "Рупите - Къщата на Ванга",
                Description = "Къщата на Баба Ванга в местността Рупите е била мястото, където известната българска пророчица е приемала нуждаещите се.",
                ImageUrl = "https://i.ibb.co/Q6wvBfd/rupite.jpg",
                RegionId = 1,
            };


            var person1 = new Person() { Id = 1, UserId = "5f378b69-c6a2-48a4-8ead-fe56eccfa3e1" };
            var person2 = new Person() { Id = 2, UserId = "4039ebe6-607a-4436-9494-9272e556d30a" };

            var user1 = new ApplicationUser() { Id = "5f378b69-c6a2-48a4-8ead-fe56eccfa3e1", FirstName = "Marian", LastName = "Ivanov", UserName = "ivanov.m29@abv.bg" };
            var user2 = new ApplicationUser() { Id = "4039ebe6-607a-4436-9494-9272e556d30a", FirstName = "Georgi", LastName = "Georgiev", UserName = "georgi.m29@abv.bg" };

            destinations = new List<Destination>()
            {
                destination1
            };

            users = new ApplicationUser[] { user1, user2 };

            persons = new List<Person>()
            {
                person1,
                person2
            };
            comments = new List<Comment>();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "DeleteCommentTestInMemoryDb") // Give a Unique name to the DB
                    .Options;
            dbContext = new ApplicationDbContext(options);
            dbContext.AddRange(users);
            dbContext.AddRange(persons);
            dbContext.AddRange(destinations);
            dbContext.AddRange(comments);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);
            service = new CommentService(repository); // Pass it to Service as dependency
        }

        [Test]
        public void Test_DeleteCommentTest()
        {
            var comment1 = new CommentViewModel() { Id = 1, Text = "Test test test.", FirstName = "Marian", LastName = "Ivanov", DestinationId = 1, PersonId = 1 };
            var comment2 = new CommentViewModel() { Id = 2, Text = "sd s sdgdgsst test.", FirstName = "Marian", LastName = "Ivanov", DestinationId = 1, PersonId = 1 };

            service.Add(comment1, 1, 1);
            service.Add(comment2, 1, 1);

            service.DeleteComment(2);

            int actualCount = repository.AllReadOnly<Comment>().Count();
            int expectedCount = 1;

            Assert.That(actualCount, Is.EqualTo(expectedCount));

        }
    }
}
