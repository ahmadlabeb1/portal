using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;
using portal.services;
using System.Threading;

namespace portal.ViewPage
{
    public abstract class CustomBaseViewPage<TModel>:RazorPage<TModel>
    {
        [RazorInject]
        public ILanguageServices LanguageServices { get; set; }
        [RazorInject]
        public ILocalizationService LocalizationService { get; set; }
        public delegate HtmlString Localizer(string resourceKey, params object[] args);
        private Localizer _localizer;
        public Localizer Localize
        {
            get
            {
                if (_localizer==null)
                {
                    var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
                    var language = LanguageServices.GetLanguageByCulture(currentCulture);
                    if (language!=null)
                    {
                        _localizer = (resourceKey, args) =>
                        {
                            var stringResource = LocalizationService.GetStringResource(resourceKey, language.Lang_Id);
                            if (stringResource == null || string.IsNullOrEmpty(stringResource.Value))
                            {
                                return new HtmlString(resourceKey);
                            }
                            return new HtmlString((args == null || args.Length == 0) ? stringResource.Value : string.Format(stringResource.Value, args));
                        };
                    }
                }
                return _localizer;
            }
        }

    }
    public abstract class CustomBaseViewPage : CustomBaseViewPage<dynamic>
    {
    }
}
