﻿using BulgarianDestinations.Core.Contracts;
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

namespace BulgarianDestinations.Tests.DestinationTests
{
    [TestFixture]
    public class SearchDestinationTest
    {
        private IEnumerable<Destination> destinations;
        private IEnumerable<Region> regions;
        private ApplicationDbContext dbContext;
        private IRepository repository;
        IDestinationService service;

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
            var destination2 = new Destination()
            {
                Id = 2,
                Name = "Мелник",
                Description = "яж е уяжшеу жш Мелник аяио жго ",
                ImageUrl = "https://i.ibb.co/Q6wvBfd/rupite.jpg",
                RegionId = 1,
            };
            var destination3 = new Destination()
            {
                Id = 3,
                Name = "Добърско - вкопаната църква",
                Description = "Късносредновековната църква „Св. св. Теодор Тирон и Теодор Стратилат“",
                ImageUrl = "https://i.ibb.co/LkYVK96/Dobursko.jpg",
                RegionId = 1,
            };
            var destination4 = new Destination()
            {
                Id = 4,
                Name = "Плажът на Иракли",
                Description = "Плажната ивица на Иракли е дълга и широка. От към входа, пясъкът е ситен и жълт.",
                ImageUrl = "https://i.ibb.co/rMX0M7n/Irakli.jpg",
                RegionId = 2
            };
            var destination5 = new Destination()
            {
                Id = 5,
                Name = "Несебър - стар град",
                Description = "Едва ли са много хората, които са посетили Стария град на Несебър и той не е станал любимо място за разходка и отдих.",
                ImageUrl = "https://i.ibb.co/BLfw4dh/Nesebar.jpg",
                RegionId = 2
            };

            var region1 = new Region()
            {
                Id = 1,
                Name = "Благоевград",
                Destinations = new List<Destination>() { destination1, destination2, destination3 }
            };
            var region2 = new Region()
            {
                Id = 2,
                Name = "Бургас",
                Destinations = new List<Destination>() { destination4, destination5 }
            };

            destinations = new List<Destination>()
            {
                destination1, destination2, destination3, destination4, destination5
            };
            regions = new List<Region>() { region1, region2 };



            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "SearchDestinationTestInMemoryDb") // Give a Unique name to the DB
                    .Options;
            dbContext = new ApplicationDbContext(options);
            dbContext.AddRange(destinations);
            dbContext.AddRange(regions);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);
            service = new DestinationService(repository); // Pass it to Service as dependency
        }
        [Test]
        public void Test_SearchDestinationTest()
        {
            var searchedDestinations = service.SearchAsync("Благоевград", "Мелник", 1, 1).Result;

            var destinations = searchedDestinations.Destinations.ToList();

            var actualCount = destinations.Count;
            var actualName = destinations[0].Name;
            var actualId = destinations[0].Id;


            var expectedCount = 1;
            var expectedName = "Мелник";
            var expectedId = 2;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
            Assert.That(actualName, Is.EqualTo(expectedName));
            Assert.That(actualId, Is.EqualTo(expectedId));


        }
    }
}
