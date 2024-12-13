using BulgarianDestinations.Core.Models.Articul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Core.Models.Order
{
    public class OrderDeatilsViewModel
    {
        public int OrderId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int PersonId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<ArticulViewModel> Articuls { get; set; } = new List<ArticulViewModel>();
    }
}
