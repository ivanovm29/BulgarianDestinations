using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Core.Models.Destination
{
    public class AllDestinationsQueryModel
    {
        public int DestinationsPerPage { get; } = 6;

        public string Region { get; set; } = null!;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; } = null!;

        public int CurrentPage { get; set; } = 1;

        public int TotalDestinationsCount { get; set; }

        public IEnumerable<string> Regions { get; set; } = null!;

        public IEnumerable<DestinationServiceModel> Destinations {  get; set; } = new List<DestinationServiceModel>();
    }
}
