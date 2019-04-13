using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MajaIvana.Models
{
    public class LoginViewModel
    {
            [Required(ErrorMessage = "Korisničko ime je obavezno")]
            [StringLength(15, MinimumLength = 6, ErrorMessage = "Dužina lozinke je između 6 i 15 karaktera")]

            public string KorisnickoIme { get; set; }

            [Required(ErrorMessage = "Lozinka je obavezna")]
            [RegularExpression("[a-zA-Z0-9]+", ErrorMessage = "Lozinka treba da sadrži mala,velika slova i cifre")]
            [StringLength(15, MinimumLength = 6, ErrorMessage = "Dužina lozinke je izmedju 6 i 15 karaktera")]
            public string Lozinka { get; set; }

            [Required(ErrorMessage = "Potvrda lozinke je obavezna")]
            [RegularExpression("[a-zA-Z0-9]+", ErrorMessage = "Lozinka treba da sadrži mala,velika slova i cifre")]
            //[StringLength(15, MinimumLength = 6, ErrorMessage = "Duzina lozinke je izmedju 6 i 15 karaktera")]
            [Compare("Lozinka", ErrorMessage = "Lozinka i potvrda lozinke moraju biti iste!")]
            public string PotvrdaLozinke { get; set; }
    }
}