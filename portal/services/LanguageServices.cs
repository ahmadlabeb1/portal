using portal.Data;
using portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portal.services
{
    public class LanguageServices : ILanguageServices
    {
        private readonly PortalContext _context; 
        public LanguageServices(PortalContext context)
        {
            _context = context;
        }
        public IEnumerable<Language> GetLanguage()
        {
            return this._context.Language.ToList();
        }

        public Language GetLanguageByCulture(string langKey)
        {
            var lang = _context.Language.FirstOrDefault(a => a.Lang_key.Trim().ToLower() == langKey.Trim().ToLower());
            return lang;
        }
    }
}
