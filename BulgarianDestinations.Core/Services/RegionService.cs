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

namespace BulgarianDestinations.Core.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRepository repository;
        public RegionService(IRepository _repository) 
        {
            repository = _repository;
        }
        public async Task<IEnumerable<DestinationViewModel>> GetAll(int regionId)
        {
            return await repository.All<Destination>()
                .OrderByDescending(d => d.Id)
                .Where(d => d.RegionId == regionId)
                .Select(d => new DestinationViewModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    ImageUrl = d.ImageUrl
                })
                .ToListAsync();
        }
    }
}
