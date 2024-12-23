﻿using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Models.Destination;
using BulgarianDestinations.Infrastructure.Data.Common;
using BulgarianDestinations.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Core.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IRepository repository;
        public DestinationService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<DestinationViewModel> DestinationInformation(int id)
        {
            var destination = await repository
                .All<Destination>()
                .Where(d => d.Id == id)
                .Select(d => new DestinationViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    ImageUrl = d.ImageUrl,
                    RegionId = d.RegionId,
                    Repository = repository
                    
                })
                .FirstOrDefaultAsync();
            return destination;
        }

        public async Task<bool> IsContain(int destinationId, int personId)
        {
            bool isContain = false;

            var destination = await repository.AllReadOnly<DestinationPerson>()
                .Where(d => d.PersonId == personId)
                .Where(d => d.DestinationId == destinationId)
                .FirstOrDefaultAsync();

            if(destination != null)
            {
                isContain = true;
            }
                
            return isContain;
        }

        public async Task<IEnumerable<string>> AllRegionsNameAsync()
        {
            return await repository.AllReadOnly<Region>()
                .Select(r => r.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<DestinationQueryServiceModel> SearchAsync(string? region = null, string? searchTerm = null, int currentPage = 1, int destinationsPerPage = 1)
        {
            var destinationsToShow = repository.AllReadOnly<Destination>().OrderBy(d => d.Name);

            if(region != null)
            {
                destinationsToShow = destinationsToShow
                    .Where(d => d.Region.Name == region)
					.OrderBy(d => d.Name);
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                destinationsToShow = destinationsToShow
                    .Where(d => d.Name.ToLower().Contains(normalizedSearchTerm))
                    .OrderBy(d => d.Name);
            }

            var destinations = await destinationsToShow
                .Skip((currentPage - 1) * destinationsPerPage)
                .Take(destinationsPerPage)
                .Select(d => new DestinationServiceModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    DestinationId = d.Id
                })
                .ToListAsync();

            int totalDestinations = await destinationsToShow.CountAsync();

            return new DestinationQueryServiceModel()
            {
                Destinations = destinations,
                TotalDestinationsCount = totalDestinations
            };
                
        }

        public async Task AddDestination(DestinationFormViewModel model)
        {
            var destination = new Destination()
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                RegionId = model.RegionId
            };

            await repository.AddAsync<Destination>(destination);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteDestination(int id)
        {
            var destination = await repository.GetById<Destination>(id);
            if (destination != null)
            {
                var comments = await repository.AllReadOnly<Comment>().Where(c => c.DestinationId == id).ToListAsync();

                if(comments != null)
                {
                    foreach (var comment in comments)
                    {
                        await repository.DeleteObjectAsync(comment);
                    }
                }

                var destinationsPersons = await repository.AllReadOnly<DestinationPerson>().Where(d => d.DestinationId == id).ToListAsync();
                if(destinationsPersons != null)
                {
                    foreach (var destinationPerson in destinationsPersons)
                    {
                        await repository.DeleteObjectAsync(destinationPerson);
                    }
                }

                await repository.DeleteAsync<Destination>(id);
                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await repository.AllReadOnly<Destination>().Where(a => a.Id == id).AnyAsync();
        }
    }
}
