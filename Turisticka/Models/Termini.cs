//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Turisticka.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Termini
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Termini()
        {
            this.Aranzmanis = new HashSet<Aranzmani>();
        }
    
        public int TerminID { get; set; }
        public System.DateTime Pocetak { get; set; }
        public System.DateTime Kraj { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aranzmani> Aranzmanis { get; set; }
    }
}
