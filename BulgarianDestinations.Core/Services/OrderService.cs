using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Models.Articul;
using BulgarianDestinations.Core.Models.Destination;
using BulgarianDestinations.Core.Models.Order;
using BulgarianDestinations.Core.Models.Region;
using BulgarianDestinations.Infrastructure.Data;
using BulgarianDestinations.Infrastructure.Data.Common;
using BulgarianDestinations.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository repository;
        public OrderService(IRepository _repository)
        {
            repository = _repository;
        }
        public IEnumerable<OrderViewModel> All()
        {

            return repository.AllReadOnly<Order>()
                .OrderBy(r => r.Id)
                .Select(r => new OrderViewModel()
                {
                    OrderId = r.Id,
                    PersonId = r.PersonId,
                    FirstName = repository.GetByIdString<ApplicationUser>(repository.GetById<Person>(r.PersonId).Result.UserId).Result.FirstName,
                    LastName = repository.GetByIdString<ApplicationUser>(repository.GetById<Person>(r.PersonId).Result.User.Id).Result.LastName
                })
                .ToList();
        }
        public async Task<OrderDeatilsViewModel> OrderInformation(int orderId)
        {
            var order = repository
                .All<Order>()
                .Where(d => d.Id == orderId)
                .Select(d => new OrderDeatilsViewModel
                {
                    OrderId = orderId,
                    PersonId = d.PersonId,
                    FirstName = repository.GetByIdString<ApplicationUser>(repository.GetById<Person>(d.PersonId).Result.UserId).Result.FirstName,
                    LastName = repository.GetByIdString<ApplicationUser>(repository.GetById<Person>(d.PersonId).Result.User.Id).Result.LastName,
                    TotalPrice = d.TotalPrice,
                    Articuls = new List<ArticulViewModel>()

                })
                .FirstOrDefault();

            var aos = await repository.AllReadOnly<ArticulOrder>().Where(o => o.OrderId == orderId).ToListAsync();
            var articuls = repository.AllReadOnly<Articul>().ToList();

            foreach (var ao in aos)
            {

                if (ao.OrderId == orderId)
                {
                    var articul = repository.AllReadOnly<Articul>().Where(a => a.Id == ao.ArticulId).FirstOrDefault();
                    var articulView = new ArticulViewModel()
                    {
                        Id = articul.Id,
                        Name = articul.Name,
                        Description = articul.Description,
                        ImageUrl = articul.ImageUrl,
                        Price = articul.Price

                    };
                    order.Articuls.Add(articulView);
                }
            }

            return order;
        }

        public async Task DeleteOrder(int orderId)
        {
            var order = await repository.GetById<Order>(orderId);
            if (order != null)
            {
                await repository.DeleteObjectAsync<Order>(order);
                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await repository.AllReadOnly<Order>().Where(a => a.Id == id).AnyAsync();
        }
    }
}
