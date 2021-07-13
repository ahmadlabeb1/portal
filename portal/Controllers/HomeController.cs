using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using portal.Data;
using portal.Models;
using portal.Models.Lang;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace portal.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PortalContext _context;
        private string _currentLanguage;

        public HomeController(ILogger<HomeController> logger,PortalContext context)
        {
            _logger = logger;
            this._context = context;
        }
        private string CurrentLanguage
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentLanguage))
                {
                    return _currentLanguage;
                }



                if (string.IsNullOrEmpty(_currentLanguage))
                {
                    var feature = HttpContext.Features.Get<IRequestCultureFeature>();
                    _currentLanguage = feature.RequestCulture.Culture.TwoLetterISOLanguageName.ToLower();
                }

                return _currentLanguage;
            }
        }
        public ActionResult RedirectToDefaultLanguage()
        {
            var lang = CurrentLanguage;
            if (lang == "ar")
            {
                lang = "en";
            }

            return RedirectToAction("Index", new { lang = lang });
        }
        public async Task<IActionResult> Index(string lang="ar")
        {
            ViewBag.dirPage = "rtl";
            ViewBag.lang = lang;
            ViewBag.linkLang = "English";
            ViewBag.href = "en";
            var cookieOptions = new CookieOptions
            {
                 
                Secure = true,

                
                HttpOnly = true,

             
                SameSite = SameSiteMode.None
            };

            Response.Cookies.Append("dirPage",ViewBag.dirPage, cookieOptions);
            var alldata = _context.Language.Where(a => a.Lang_key.Contains(lang)).Select(s => s);
            if (lang=="en")
            {
                ViewBag.dirPage = "ltr";
                ViewBag.lang = lang;
                ViewBag.linkLang = "عربي";
                ViewBag.href = "ar";
                ViewBag.styleImage="image-size";
            }
            return View(await alldata.ToListAsync());
        }
        //public IActionResult Index(string lang="ar")
        //{
        //    var all_data= _context.Language.Select(a => a).Where(a => a.Lang_key.Contains(lang));
        //    return View(all_data);
        //}

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
