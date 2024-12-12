using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Core.Models.Destination
{
    public class DestinationServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DestinationId { get; set; }
        
    }
}
