using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Infrastructure.Data.Models
{
    public class DestinationPerson
    {
        [Required]
        public int DestinationId { get; set; }

        [ForeignKey(nameof(DestinationId))]
        public Destination Destination { get; set; } = null!;

        [Required]
        public int PersonId { get; set; }

        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; } = null!;
    }
}
