using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Infrastructure.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PersonId { get; set; }

        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        public List<Articul> Articuls { get; set; } = new List<Articul>();

    }
}
