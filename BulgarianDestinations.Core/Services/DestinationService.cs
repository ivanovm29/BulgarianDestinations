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

    }
}
