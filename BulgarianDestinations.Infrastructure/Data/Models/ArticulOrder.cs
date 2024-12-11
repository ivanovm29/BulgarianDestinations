using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Infrastructure.Data.Models
{
    public class ArticulOrder
    {
        [Required]
        public int ArticulId { get; set; }

        [ForeignKey(nameof(ArticulId))]
        public Articul Articul { get; set; } = null!;

        [Required]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;
    }
}
