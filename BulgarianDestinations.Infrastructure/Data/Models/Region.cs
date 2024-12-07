using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BulgarianDestinations.Infrastructure.Data.Constants.DataConstants;

namespace BulgarianDestinations.Infrastructure.Data.Models
{
    public class Region
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public List<Destination> Destinations { get; set; } = new List<Destination>();

    }
}
