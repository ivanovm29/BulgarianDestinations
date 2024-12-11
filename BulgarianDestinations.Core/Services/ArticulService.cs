using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Models.Articul;
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
    public class ArticulService : IArticulService
    {
        private readonly IRepository repository;
        public ArticulService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<ArticulViewModel>> All()
        {
            return await repository.All<Articul>()
                .OrderByDescending(d => d.Id)
                .Select(d => new ArticulViewModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    ImageUrl = d.ImageUrl,
                    Price = d.Price
                })
                .ToListAsync();
        }

        public async Task<ArticulViewModel> ArticulInformation(int id)
        {
            var articul = await repository
                .All<Articul>()
                .Where(d => d.Id == id)
                .Select(d => new ArticulViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    ImageUrl = d.ImageUrl,
                    Price= d.Price,

                })
                .FirstOrDefaultAsync();
            return articul;
        }

        public async Task GetArticul(int articulId, int personId)
        {
            await repository.AddAsync<ArticulPerson>(new ArticulPerson
            {
                ArticulId = articulId,
                PersonId = personId
            });
            await repository.SaveChangesAsync();
        }
    }
}
