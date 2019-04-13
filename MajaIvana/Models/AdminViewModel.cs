using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MajaIvana.Models
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

        public int SifraAranzmana { get; set; }
        public string NazivHotela { get; set; }
        public string VrstaUsluge { get; set; }
        public string TerminPutovanja { get; set; }
        public double Cena { get; set; }
        public int Rapolozivost { get; set; }
        public int Aktivan { get; set; }
    }
}