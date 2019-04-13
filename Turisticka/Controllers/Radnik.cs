using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;  //dodato
//Branislava
namespace MajaIvana.Models
{
    public class Radnik
    {
        public static List<Korisnici> PrikaziKorisnike()
        {
            using (ProbnaAgencijaEntities1 dbEntitet = new ProbnaAgencijaEntities1())
            {
                List<Korisnici> korisnici = (from k in dbEntitet.Korisnicis
                                             where k.Uloga==3
                                             select k ).ToList();
                return korisnici;
            }
        }

        public static void DodajKorisnika(Korisnici korisnik)
        {
            using (ProbnaAgencijaEntities1 dbEntitet = new ProbnaAgencijaEntities1())
            {
                try
                {
                        dbEntitet.Korisnicis.Add(korisnik);
                        dbEntitet.SaveChanges();
                }
                catch (Exception) { }
            }
        }

        //ovo meni ne treba zatrebaće za Rezervacije

        //private void PopuniSifreKorisnika()
        //{
        //    SelectList items = Radnik.PopuniListuKorisnikaID();
        //    if (items != null)
        //    {
        //        ViewBag.korisnici = items;
        //    }
        //}
    }
}