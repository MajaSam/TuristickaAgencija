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
    
    public partial class Hoteli
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hoteli()
        {
            this.Aranzmanis = new HashSet<Aranzmani>();
        }
    
        public int HotelID { get; set; }
        public string Naziv { get; set; }
        public int BrojZvezdica { get; set; }
        public int DestinacijaID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aranzmani> Aranzmanis { get; set; }
        public virtual Destinacije Destinacije { get; set; }
    }
}
