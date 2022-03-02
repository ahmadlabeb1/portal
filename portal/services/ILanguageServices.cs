using portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portal.services
{
    public interface ILanguageServices
    {
        IEnumerable<Language> GetLanguage();
        Language GetLanguageByCulture(string culture);
    }
}
