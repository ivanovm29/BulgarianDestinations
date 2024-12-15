using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Models.Articul;
using BulgarianDestinations.Core.Models.Destination;
using BulgarianDestinations.Infrastructure.Data;
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

        public async Task AddArticul(ArticulFormViewModel model)
        {
            var articul = new Articul()
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
            };

            await repository.AddAsync<Articul>(articul);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteArticul(int id)
        {
            var articul = await repository.GetById<Articul>(id);
            if (articul != null)
            {

                var articulssPersons = await repository.AllReadOnly<ArticulPerson>().Where(a => a.ArticulId == id).ToListAsync();
                if (articulssPersons != null)
                {
                    foreach (var articulPerson in articulssPersons)
                    {
                        await repository.DeleteObjectAsync(articulPerson);
                    }
                }

                await repository.DeleteAsync<Articul>(id);
                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> Exists(int id)
        {
          return await repository.AllReadOnly<Articul>().Where(a => a.Id == id).AnyAsync();
        }
    }
}
