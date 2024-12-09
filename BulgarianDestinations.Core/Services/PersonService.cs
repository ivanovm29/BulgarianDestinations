using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Models.Destination;
using BulgarianDestinations.Infrastructure.Data.Common;
using BulgarianDestinations.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace BulgarianDestinations.Core.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepository repository;

        public PersonService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task CreateAsync(string userId)
        {
            await repository.AddAsync(new Person
            {
                UserId = userId,
            });

            await repository.SaveChangesAsync();
        }

        public async Task<bool> ExistsById(string userId)
        {
            return await repository.AllReadOnly<Person>()
                .AnyAsync(p => p.UserId == userId);
        }

        public async Task GetDestination(int destinationId, int personId)
        {
            var destination = await repository
            .All<Destination>()
            .Where(d => d.Id == destinationId)
            .FirstOrDefaultAsync();

            var person = await repository
                .All<Person>()
                .Where(d => d.Id == personId)
                .FirstOrDefaultAsync();
            if (person != null && destination != null)
            {
                var personC = await repository.AllReadOnly<DestinationPerson>().FirstOrDefaultAsync(d => d.PersonId == personId);
                var destinationC = await repository.AllReadOnly<DestinationPerson>().FirstOrDefaultAsync(d => d.DestinationId == destinationId);
                bool isContain = false;
                if (personC != null && destinationC != null)
                {
                    isContain = true;
                }
                if (isContain == false)
                {
                    await repository.AddAsync<DestinationPerson>(new DestinationPerson
                    {
                        DestinationId = destinationId,
                        PersonId = personId
                    });
                    await repository.SaveChangesAsync();
                }
            }
        }

        public async Task GetOutDestination(int destinationId, int personId)
        {
            var destination = await repository
            .All<Destination>()
            .Where(d => d.Id == destinationId)
            .FirstOrDefaultAsync();

            var person = await repository
                .All<Person>()
                .Where(d => d.Id == personId)
                .FirstOrDefaultAsync();
            if (person != null && destination != null)
            {
                //var dp = repository.GetByIdCollection<DestinationPerson>(destinationId, personId);

                await repository.DeleteCollectionAsync<DestinationPerson>(destinationId, personId);

                await repository.SaveChangesAsync();
                
            }
        }

    }
}
