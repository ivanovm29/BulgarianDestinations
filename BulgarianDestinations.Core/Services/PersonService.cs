using BulgarianDestinations.Core.Contracts;
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
                UserId = userId 
            });

            await repository.SaveChangesAsync();
        }

        public async Task<bool> ExistsById(string userId)
        {
            return await repository.AllReadOnly<Person>()
                .AnyAsync(p => p.UserId == userId);
        }
    }
}
