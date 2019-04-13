using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Turisticka.Models
{
    public class Admin
    {
        public static List<Destinacije> PrikaziDestinacije()
        {
            using (ProbnaAgencijaEntities dbEntitet = new ProbnaAgencijaEntities())
            {
                List<Destinacije> destinacije = (from d in dbEntitet.Destinacijes
                                                 select d).ToList();
                return destinacije;
            }
        }

        public static List<Hoteli> PrikaziHotele()
        {
            using (ProbnaAgencijaEntities dbEntitet = new ProbnaAgencijaEntities())
            {
                List<Hoteli> hoteli = (from h in dbEntitet.Hotelis
                                       select h).ToList();

                return hoteli;
            }
        }


        public static int Sifra { get; set; }
        public static SelectList PopuniListuDestinacijaID()
        {
            ProbnaAgencijaEntities dbEntitet = new ProbnaAgencijaEntities();
            IEnumerable<SelectListItem> destinacije = (from a in dbEntitet.Destinacijes select a).AsEnumerable().Select(a => new SelectListItem() { Text = a.Grad, Value = a.DestinacijaID.ToString() });

            return new SelectList(destinacije, "Value", "Text", Sifra);
        }


        //dodaje novu destinaciju
        public static void DodajDestinaciju(Destinacije destinacija)
        {
            using (ProbnaAgencijaEntities dbEntitet = new ProbnaAgencijaEntities())
            {
                try
                {
                    dbEntitet.Destinacijes.Add(destinacija);
                    dbEntitet.SaveChanges();
                }
                catch (Exception) { }
            }
        }

        //dodaje novi hotel
        public static void DodajHotel(Hoteli hotel)
        {
            using (ProbnaAgencijaEntities dbEntitet = new ProbnaAgencijaEntities())
            {
                try
                {
                    dbEntitet.Hotelis.Add(hotel);
                    dbEntitet.SaveChanges();
                }
                catch (Exception) { }
            }
        }

    }
}