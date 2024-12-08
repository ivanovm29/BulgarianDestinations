using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Core.Contracts
{
    public interface IPersonService
    {
        Task<bool> ExistsById(string userId);
        Task CreateAsync(string userId);
    }
}
