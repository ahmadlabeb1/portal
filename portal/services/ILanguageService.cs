using portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portal.services
{
   public interface ILanguageService
    {
        IEnumerable<Language> GetLanguages();
        Language GetLanguageByCulture(string LangKey);
    }
}
