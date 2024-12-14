using BulgarianDestinations.Infrastructure.Data.Common;
using BulgarianDestinations.Infrastructure.Data.Models;
using static BulgarianDestinations.Core.Constants.RoleConstants;
namespace System.Security.Claims
{
    public static class ClaimsPrincipalExtensions
    {
         
        public static string GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRole);
        }

    }
}
