﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulgarianDestinations.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}