using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace nowui.Controllers
{
   
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}