using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Turisticka.Models
{
    public class AdminViewModel
    {
        [Required(ErrorMessage = "Unesite sifru destinacije")]
        public int DestinacijaID { get; set; }

        [Required(ErrorMessage = "Unesite ime zemlje")]
        public string Zemlja { get; set; }

        [Required(ErrorMessage = "Unesite ime grada")]
        public string Grad { get; set; }

        [Required(ErrorMessage = "Unesite sifru hotela")]
        public int HotelID { get; set; }

        [Required(ErrorMessage = "Unesite naziv hotela")]
        public string Naziv { get; set; }

        public int BrojZvezdica { get; set; }
    }
}