using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BulgarianDestinations.Infrastructure.Data.Constants.DataConstants;

namespace BulgarianDestinations.Infrastructure.Data.Models
{
    public class Articul
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(ArticulDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
