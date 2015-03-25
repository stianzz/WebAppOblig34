using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oblig3MVC.Models
{
    public class faq
    {
        public int id { get; set; }
        [Required]
        [RegularExpression("^[a-zæøåA-ZÆØÅ. \\-]{2,30}$")]
        public string problem { get; set; }
        [Required]
        [RegularExpression("^[a-zøæåA-ZØÆÅ. \\-]{2,30}$")]
        public string losning { get; set; }
        [Required]
        [RegularExpression("^[a-zøæåA-ZØÆÅ.0-9 \\-]{2,30}$")]
        public string katid { get; set; }
        [Required]
        [RegularExpression("^[a-zøæåA-ZØÆÅ.0-9 \\-]{2,30}$")]
        public string kategori { get; set; }
        
    }
}
