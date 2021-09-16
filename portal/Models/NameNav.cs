using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace portal.Models
{
    public class NameNav
    {
        [Key]
        public int Id_nameNav { get; set; }
        public string nameNav { get; set; }
        public string url { get; set; }
        public int Lang_id { get; set; }
        [ForeignKey("Lang_id")]
        public Language Language { get; set; }
        public virtual IEnumerable<subNameNav> SubNameNavs { get; set; }
    }
    public class subNameNav
    {
        [Key]
        public int Id_subNav { get; set; }
        public string nameSubNav { get; set; }
        public string url { get; set; }
        public int NavName_id { get; set; }
        [ForeignKey("NavName_id")]
        public virtual NameNav NavsName { get; set; }
    }
}
