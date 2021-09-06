using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace portal.Models
{
    public class RelatedIns
    {
        [Key]
        public int id_Related { get; set; }
        [DisplayName("صورة")]
        public byte[] images_Related { get; set; }
        [Display(Name ="اسم المؤسسة")]
        public string name_Related { get; set; }
        [DisplayName("الرابط")]
        public string link_Related { get; set; }
        [DisplayName("فعال")]
        public bool isActive { get; set; }

        
        public int Lang_id { get; set; }
        [ForeignKey("Lang_id")]
        [Display(Name = "اللغة")]

        public virtual Language  language_related{ get; set; }
    }
}
