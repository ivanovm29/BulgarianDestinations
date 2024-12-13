using BulgarianDestinations.Core.Models.Articul;
using BulgarianDestinations.Core.Models.Destination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Core.Contracts
{
    public interface ICartServices
    {
        Task<IEnumerable<ArticulViewModel>> All();

        Task RemoveArticul(int articulId, int personId);

        Task<decimal> TotalPrice(int personId);

        Task OrderArticuls(int personId);
    }
}
