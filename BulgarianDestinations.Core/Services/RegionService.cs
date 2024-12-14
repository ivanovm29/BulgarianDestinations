using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Models.Destination;
using BulgarianDestinations.Core.Models.Region;
using BulgarianDestinations.Infrastructure.Data.Common;
using BulgarianDestinations.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        public async Task<IEnumerable<RegionViewModel>> All()
        {
            return await repository.AllReadOnly<Region>()
                .OrderBy(r => r.Name)
                .Select(r => new RegionViewModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                })
                .ToListAsync();
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

        public async Task<string> GetColor(int percent)
        {
            string color = "#88a4bc";
            if (percent > 0 && percent < 100) 
            {
                color = "#f7f305";
            }
            else if (percent == 100)
            {
                color = "#0bc208";
            }

            return color;

        }

        public async Task<string> GetName(int regionId) 
        {
            var region = await repository.AllReadOnly<Region>().FirstOrDefaultAsync(r => r.Id == regionId);

            return region?.Name ?? string.Empty;
        }

        public async Task<IEnumerable<RegionViewModel>> GetCategories()
        {
            return await repository.AllReadOnly<Region>()
                .Select(c => new RegionViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await repository.AllReadOnly<Region>().Where(a => a.Id == id).AnyAsync();
        }
    }
}
