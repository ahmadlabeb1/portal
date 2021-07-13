using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace portal.Models
{
    public class SubNavigationItem
    {
        [Key]
        public int subNav_id { get; set; }
        public string subNav_name { get; set; }
        public string subNav_url { get; set; }
        public bool isActive { get; set; }
        public int Lang_id { get; set; }
        public int Nav_id { get; set; }
        //[ForeignKey("Lang_id")]
        //public virtual Language language { get; set; }
        [ForeignKey("Nav_id")]
        public virtual NavigationItem navigationItem { get; set; }
    }
}
