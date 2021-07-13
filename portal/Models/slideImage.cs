using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace portal.Models
{
    public class slideImage
    {
        [Key]
        public int Id_slid { get; set; }
        public string Title { get; set; }
        public string discrbtion { get; set; }
        public string url { get; set; }
        public byte[] Image { get; set; }
        public int id_lang { get; set; }
        [ForeignKey("id_lang")]
        public virtual Language languageImage { get; set; }
    }
}
