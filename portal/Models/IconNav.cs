using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace portal.Models
{
    public class IconNav
    {
        [Key]
        public int id_IconNav { get; set; }
        public string nameHint { get; set; }
        public string nameNav { get; set; }
        public string Name { get; set; }
        public string urlNav { get; set; }
        public int lang_Id { get; set; }
        [ForeignKey("lang_Id")]
        public virtual Language language { get; set; }
        public virtual IconNav iconNav { get; set; }
    }
}
