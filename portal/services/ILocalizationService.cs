using portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portal.services
{
    public interface ILocalizationService
    {
        TextResource GetTextResource(string resourceKey, int languageId);
    }
}
