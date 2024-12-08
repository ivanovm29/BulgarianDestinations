using BulgarianDestinations.Core.Models.Destination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Core.Contracts
{
    public interface IRegionService
    {
        Task<IEnumerable<DestinationViewModel>> GetAll(int regionId);
    }
}
