using BulgarianDestinations.Core.Models.Articul;
using BulgarianDestinations.Core.Models.Comment;
using BulgarianDestinations.Core.Models.Destination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Core.Contracts
{
    public interface IArticulService
    {
        Task<IEnumerable<ArticulViewModel>> All();

        Task<ArticulViewModel> ArticulInformation(int id);

        Task GetArticul(int articulId, int personId);

        Task AddArticul(ArticulFormViewModel model);

        Task DeleteArticul(int id);
    }
}
