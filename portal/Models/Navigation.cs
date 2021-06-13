using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace portal.Models
{
    public class Navigation
    {
        [Key]
        public int Nav_Id { get; set; }
        [DisplayName("اسم ارابط")]
        public string nav_Name { get; set; }
        [DisplayName("عنوان الرابط")]
        public string nav_Url { get; set; }
        [DisplayName("موقع الرابط")]
        public string nav_Location { get; set; }
        [DisplayName("حالة الرابط")]
        public bool isActive { get; set; }
        [DisplayName("راوابط داخلية")]
        public bool isGroup { get; set; }
        [DisplayName("لغة الرابط")]
        public int lang_id { get; set; }
        [ForeignKey("lang_id")]
        public virtual Language Language { get; set; }
    }
}
