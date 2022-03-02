using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using portal.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace portal.ViewPage
{
    public class BaseController : Controller
    {
        private readonly ILanguageServices _languageServices;
        private readonly ILocalizationService _localizationService;
        public BaseController(ILanguageServices languageServices,ILocalizationService localizationService)
        {
            _languageServices = languageServices;
            _localizationService = localizationService;
        }
        public HtmlString Localize(string resourceKey,params object[] args)
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            var language = _languageServices.GetLanguageByCulture(currentCulture);
            if (language!=null)
            {
                var stringResource = _localizationService.GetStringResource(resourceKey, language.Lang_Id);
                if (stringResource==null||string.IsNullOrEmpty(stringResource.Value))
                {
                    return new HtmlString(resourceKey);
                }
                return new HtmlString((args == null | args.Length == 0) ? stringResource.Value : string.Format(stringResource.Value, args));
            }
            return new HtmlString(resourceKey);
        }
      
    }
}
