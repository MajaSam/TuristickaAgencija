using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MajaIvana.Models
{
    public class AranzmanViewModel
    {

        public int SifraAranzmana { get; set; }
        public string NazivHotela { get; set; }
        public string VrstaUsluge { get; set; }
        public string TerminPutovanja { get; set; }
        public double Cena { get; set; }
        public int Rapolozivost { get; set; }
        public int Aktivan { get; set; }

    }
}