//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MajaIvana.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rezervacije
    {
        public int RezervacijaID { get; set; }
        public int KorisnikID { get; set; }
        public int AranzmanID { get; set; }
        public int Aktivan { get; set; }
    
        public virtual Aranzmani Aranzmani { get; set; }
        public virtual Korisnici Korisnici { get; set; }
    }
}
