using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace portal.Models
{
    public class Language
    {
        [Key]
        public int Lang_Id { get; set; }
        [Display(Name ="اللغة")]
        public string Lang_name { get; set; }
        [Display(Name ="مفتاح اللغة")]
        public string Lang_key { get; set; }

    }
}
