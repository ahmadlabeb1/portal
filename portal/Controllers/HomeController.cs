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
using portal.services;
using portal.ViewPage;
using Microsoft.AspNetCore.Localization;

namespace portal.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PortalContext _context;
        public HomeController( PortalContext context,ILanguageServices languageServices,ILocalizationService localizationService):base(languageServices,localizationService)
        {
           
            this._context = context;
        }
        public  IActionResult ChangeLanguage(string culture,string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions
            {
                Expires=DateTimeOffset.UtcNow.AddDays(7)
            });

        
            //if (culture=="ar")
            //{
            //    Response.Cookies.Append("dir", "rtl");
            //}
            //else if (culture=="en")
            //{
            //    Response.Cookies.Append("dir", "ltr");
            //}
            return LocalRedirect(returnUrl);
        }
        public IActionResult Index()
        {

            // var alldata = await _context.IconNav.Select(a=>a).ToListAsync();
            //var data = _context.IconNav.ToList();
            //icon.Icon = data.Select(a => new IconNav
            //{
            //   id_IconNav=a.id_IconNav
              
            //}).ToList();
            return View();
        }

        public IActionResult viewActionR()
        {
            return ViewComponent("_IconNavigation", new { maxPriority = 3, isDone = false });
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
