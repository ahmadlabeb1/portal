using portal.Data;
using portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portal.services
{
    public class LanguageService : ILanguageService
    {
        private readonly PortalContext _context;
        public LanguageService(PortalContext context)
        {
            _context = context;
        }
        public Language GetLanguageByCulture(string LangKey)
        {
            return _context.Language.FirstOrDefault(x =>
                x.Lang_key.Trim().ToLower() == LangKey.Trim().ToLower());
        }

        public IEnumerable<Language> GetLanguages()
        {
            return _context.Language.ToList();
        }
    }
}
