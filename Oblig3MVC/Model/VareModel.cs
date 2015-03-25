using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Oblig3MVC.Model
{
    public class VareModel
    {
        public int VareId { get; set; }
        public string Navn { get; set; }
        public decimal Pris { get; set; }
        public int Antall { get; set; }
        public string VareArtUrl { get; set; }
        [Display(Name= "Kategori")]
        public string KatNavn { get; set; }
        public string Land { get; set; }
    }

}
