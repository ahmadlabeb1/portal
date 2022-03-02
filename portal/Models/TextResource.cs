using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portal.Models
{
    public class TextResource
    {
        public int Id { get; set; }
        public int? LanguageId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual Language Language { get; set; }
    }
}
