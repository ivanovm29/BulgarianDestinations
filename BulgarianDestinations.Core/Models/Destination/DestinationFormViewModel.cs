using BulgarianDestinations.Core.Models.Region;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Core.Models.Destination
{
    public class DestinationFormViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int RegionId { get; set; }
        public IEnumerable<RegionViewModel> Regions { get; set; } = new List<RegionViewModel>();
    }
}
