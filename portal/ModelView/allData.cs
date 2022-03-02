using portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portal.ModelView
{
    public class allData
    {
        public Language language { get; set; }
        public IconNav IconNav { get; set; }
    }
    public class navs
    {
        public NameNav nameNav { get; set; }
        public subNameNav subNameNav { get; set; }
    }
    public class IconNavName
    {
        public List<IconNav> Icon { get; set; }
        public List<NameNav> nameNav { get; set; }
    }
}
