using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace portal.Models
{
    public class Language
    {
        [Key]
        public int Lang_Id { get; set; }
        [DisplayName("اللغة")]
        public string Lang_name { get; set; }
        [DisplayName("مفتاح اللغة")]
        public string Lang_key { get; set; }
        public ICollection<Navigation> navigations { get; set; }
    }
}
