using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using portal.Data;
using portal.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PortalContext _context;

  
        // GET: Navigations
        
        public HomeController(ILogger<HomeController> logger, PortalContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var dataNav = _context.Navigation.Select(a => a.nav_Name);
            var data = _context.Navigation.Select(a => a);
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
