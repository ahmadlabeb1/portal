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
        public JsonResult IconNav()
        {
            var data = _context.IconNav.Select(a => a).Where(a => a.language.Lang_key.Contains("ar"));
            return Json(data);
        }
        public JsonResult NameNavs()
        {
            var navs = _context.NameNav.Join(_context.SubNameNav,
                n => n.Id_nameNav,
                s => s.NavName_id,
                (n, s) => new navs
                {
                    nameNav = new NameNav
                    {
                        Id_nameNav = n.Id_nameNav,
                        nameNav = n.nameNav,
                        url = n.url,
                        Language = new Language
                        {
                            Lang_Id=n.Language.Lang_Id,
                            Lang_key = n.Language.Lang_key,
                            Lang_name=n.Language.Lang_name
                             
                              
                   
                        }
                    },
                    subNameNav = new subNameNav
                    {
                        Id_subNav = s.Id_subNav,
                        nameSubNav = s.nameSubNav,
                        url = s.url
                    }
                }).Where(w => w.nameNav.Language.Lang_key.Contains("ar")); 
            return Json(navs);
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
