using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Models.Articul;
using BulgarianDestinations.Infrastructure.Data.Common;
using BulgarianDestinations.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BulgarianDestinations.Core.Services
{
    public class CartServices : ICartServices
    {
        private readonly IRepository repository;
        public CartServices(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<IEnumerable<ArticulViewModel>> All(int personId)
        {
            return await repository.All<ArticulPerson>()
                .OrderByDescending(d => d.ArticulId)
                .Where(d => d.PersonId == personId)
                .Select(d => new ArticulViewModel()
                    {
                    Id = d.Articul.Id,
                    Name = d.Articul.Name,
                    Description = d.Articul.Description,
                    ImageUrl = d.Articul.ImageUrl,
                    Price = d.Articul.Price
                })
                .ToListAsync();
        }

        public async Task<decimal> TotalPrice(int personId)
        {
            decimal totalPrice = 0;

           var collection = await repository.AllReadOnly<ArticulPerson>().
                Where(p => p.PersonId == personId)
                .ToListAsync();
            foreach (var item in collection)
            {
                var articul = await repository.GetById<Articul>(item.ArticulId);
                totalPrice += articul.Price;
            }

            return totalPrice;
        }

        public async Task RemoveArticul(int articulId, int personId)
        {
            await repository.DeleteCollectionAsync<ArticulPerson>(articulId, personId);
            await repository.SaveChangesAsync();
        }
    }
}
