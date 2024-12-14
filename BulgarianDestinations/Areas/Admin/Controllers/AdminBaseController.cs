using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BulgarianDestinations.Core.Constants.RoleConstants;

namespace BulgarianDestinations.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {

    }
}
