using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BulgarianDestinations.Infrastructure.Data.Constants.DataConstants;

namespace BulgarianDestinations.Core.Models.Articul
{
    public class ArticulFormViewModel
    {

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(ArticulDescriptionMaxLength, MinimumLength = ArticulDescriptionMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [Range(typeof(decimal),
            ArticulPriceMin,
            ArticulPriceMax,
            ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }
    }
}
