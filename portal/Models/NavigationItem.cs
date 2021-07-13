using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace portal.Models
{
    public class NavigationItem
    {
        [Key]
        public int Nav_id { get; set; }
        public string Nav_name { get; set; }
        public int Nav_url { get; set; }
        public bool isActive { get; set; }
        public int Lang_id { get; set; }
        [ForeignKey("Lang_id")]
        public virtual Language language { get; set; }
        public virtual ICollection<SubNavigationItem> subnavigationitems { get; set; }
    }

}
