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
        public async Task<IEnumerable<ArticulViewModel>> All()
        {
            return await repository.All<ArticulPerson>()
                .OrderByDescending(d => d.ArticulId)
                .Select(d => new ArticulViewModel()
                    {
                    Id = d.Articul.Id,
                    Name = d.Articul.Name,
                    Description = d.Articul.Description,
                    ImageUrl = d.Articul.ImageUrl,
                    Price = d.Articul.Price,
                    PersonId = d.PersonId
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

        public async Task OrderArticuls(int personId)
        {
            var articulsPersons = await repository.All<ArticulPerson>().Where(p => p.PersonId == personId).ToListAsync();
            var articuls = new List<Articul>();
            decimal totalPrice = 0;
            foreach (var item in articulsPersons)
            {
                decimal price = repository.GetById<Articul>(item.ArticulId).Result.Price;
                totalPrice += price;
                articuls.Add(item.Articul);
                await repository.DeleteSingleObjectAsync<ArticulPerson>(item);
            }

            await repository.AddAsync<Order>(new Order()
            {
                PersonId = personId,
                Articuls = articuls,
                TotalPrice = totalPrice,
            }) ;

            await repository.SaveChangesAsync();
        }
    }
}
