using BulgarianDestinations.Core.Models.Destination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace BulgarianDestinations.Core.Contracts
{
    public interface IPersonService
    {
        Task<bool> ExistsById(string userId);
        Task CreateAsync(string userId);

        Task GetDestination(int destinationId, int personId);
        Task GetOutDestination(int destinationId, int personId);





    }
}
