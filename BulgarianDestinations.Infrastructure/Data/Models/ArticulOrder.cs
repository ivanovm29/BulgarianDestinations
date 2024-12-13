using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Infrastructure.Data.Models
{
    public class ArticulOrder
    {
        public int ArticulId { get; set; }

        [ForeignKey(nameof(ArticulId))]
        public Articul Articuls { get; set; } = null!;

        
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Orders { get; set; } = null!;
    }
}
