using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BulgarianDestinations.Infrastructure.Data.Common;
using BulgarianDestinations.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



namespace BulgarianDestinations.Core.Models.Destination
{
    public class DestinationViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int RegionId { get; set; }
        public IRepository Repository { get; set; } = null!;

        public async Task<bool> IsContain(int destinationId, int personId)
        {
            bool isContain = false;
            var dp = await Repository.GetByIdCollection<DestinationPerson>(destinationId, personId);
            if(dp != null)
            {
                isContain = true;
            }
            return isContain;
        }
        public async Task<int> GetUserId(string userId)
        {
            var person = Repository.AllReadOnly<Person>()
                .Where(p => p.UserId == userId)
                .FirstOrDefault();
            return person.Id;
        }
    }
}
