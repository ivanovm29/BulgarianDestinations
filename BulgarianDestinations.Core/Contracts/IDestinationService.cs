using BulgarianDestinations.Core.Models.Destination;
using BulgarianDestinations.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Core.Contracts
{
    public interface IDestinationService
    {
        Task<DestinationViewModel> DestinationInformation(int id);
        Task<bool> IsContain(int destinationId, int personId);

        Task<IEnumerable<string>> AllRegionsNameAsync();

        Task<DestinationQueryServiceModel> SearchAsync(
            string? region = null,
            string? searchTerm = null,
            int currentPage = 1,
            int destinationsPerPage = 1
            );

        Task AddDestination(DestinationFormViewModel model);
    }


}
