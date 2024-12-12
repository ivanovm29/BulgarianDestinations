using BulgarianDestinations.Core.Models.Destination;
using BulgarianDestinations.Core.Models.Region;
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

        Task<IEnumerable<RegionViewModel>> All();
        Task<string> GetName(int regionId);

        Task<string> GetColor(int percent);

        Task<IEnumerable<RegionViewModel>> GetCategories();
    }
}
