
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace portal.Models
{
    public class CardMultiAdv
    {
        [Key]
        public int Id_CardM { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public byte[] ImageCard { get; set; }
        public int Id_lang { get; set; }
        [ForeignKey("Id_lang")]
        public virtual Language language { get; set; }

    }
}
