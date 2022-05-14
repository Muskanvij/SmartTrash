using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace nowui.Controllers
{
    [Authorize]
    public class WorkerDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}