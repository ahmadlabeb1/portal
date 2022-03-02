using portal.Data;
using portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portal.services
{
    public class Localization : ILocalizationService
    {
        private readonly PortalContext _context;
        public Localization(PortalContext context)
        {
            _context = context;
        }
        public TextResource GetStringResource(string resourceKey, int languageId)
        {
            var textRes = _context.textResources.FirstOrDefault(a => a.Name.Trim().ToLower() == resourceKey.Trim().ToLower() && a.LanguageId == languageId);
            return textRes;
        }
    }
}
