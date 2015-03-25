using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oblig3MVC.Models
{
    public class Bruker
    {


        [Required(ErrorMessage = "Fornavn må oppgis")]
        [StringLength(50, ErrorMessage = "Maks 50 tegn i fornavn")]
        public string Fornavn { get; set; }
       
        [Required(ErrorMessage = "Etternavn må oppgis")]
        [StringLength(50, ErrorMessage = "Maks 50 tegn i etternavn")]
        public string Etternavn { get; set; }
        
        [Required(ErrorMessage = "Telefonnummer må oppgis")]
        [StringLength(8, ErrorMessage = "Maks 8 tegn i telefonnummeret")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "E-mailadresse må oppgis")]
        [StringLength(50, ErrorMessage = "Maks 50 tegn for E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Spørsmål må oppgis")]
        [StringLength(200, ErrorMessage = "Maks 200 tegn per spørsmål.")]
        public string Spørsmål { get; set; }

    }
}
