using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Core.Models.Destination
{
    public class DestinationQueryServiceModel
    {
        public int TotalDestinationsCount { get; set; }
        
        public IEnumerable<DestinationServiceModel> Destinations { get; set; } = new List<DestinationServiceModel>();
    }
}
