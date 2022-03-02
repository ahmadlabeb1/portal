using portal.Data;
using portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portal.services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly PortalContext _context;
        public LocalizationService(PortalContext context)
        {
            _context = context;
        }
        public TextResource GetTextResource(string resourceKey, int languageId)
        {
            return _context.textResources.FirstOrDefault(x =>
                               x.Name.Trim().ToLower() == resourceKey.Trim().ToLower()
                               && x.LanguageId == languageId);
        }
    }
}
