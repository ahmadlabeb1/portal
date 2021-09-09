using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using portal.Data;
using portal.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using portal.ModelView;
namespace portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PortalContext _context;
        public HomeController(ILogger<HomeController> logger, PortalContext context)
        {
            _logger = logger;
            this._context = context;
        }
        public IActionResult Index()
        {
            // var alldata = await _context.IconNav.Select(a=>a).ToListAsync();
            var data = _context.IconNav.Select(a => a);
            return View(data.ToList());
        }
        public JsonResult dataIcon()
        {
            var data = _context.IconNav.Select(a => a).Where(a=>a.language.Lang_key.Contains("ar"));
            return Json(data);
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
