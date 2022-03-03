using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace portal.Models
{
    public class Language
    {
        //public Language()
        //{
        //    textResources = new HashSet<TextResource>();
        //}
        [Key]
        public int Lang_Id { get; set; }
        [Display(Name ="اللغة")]
        public string Lang_name { get; set; }
        [Display(Name ="مفتاح اللغة")]
        public string Lang_key { get; set; }

     
        public virtual ICollection<TextResource> textResources { get; set; }
        public virtual ICollection<IconNav> IconNavs { get; set; }
    }
}
