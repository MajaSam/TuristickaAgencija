using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MajaIvana.Models
{
    public class Admin
    {
        //IVANA

        public static List<Destinacije> PrikaziDestinacije()
        {
            using (ProbnaAgencijaEntities1 dbEntitet = new ProbnaAgencijaEntities1())
            {
                List<Destinacije> destinacije = (from d in dbEntitet.Destinacijes
                                                 select d).ToList();
                return destinacije;
            }
        }

        public static List<Hoteli> PrikaziHotele()
        {
            using (ProbnaAgencijaEntities1 dbEntitet = new ProbnaAgencijaEntities1())
            {
                List<Hoteli> hoteli = (from h in dbEntitet.Hotelis
                                       select h).ToList();

                return hoteli;
            }
        }


        public static int Sifra { get; set; }
        public static SelectList PopuniListuDestinacijaID()
        {
            ProbnaAgencijaEntities1 dbEntitet = new ProbnaAgencijaEntities1();
            IEnumerable<SelectListItem> destinacije = (from a in dbEntitet.Destinacijes select a).AsEnumerable().Select(a => new SelectListItem() { Text = a.Grad, Value = a.DestinacijaID.ToString() });

            return new SelectList(destinacije, "Value", "Text", Sifra);
        }


        //dodaje novu destinaciju
        public static void DodajDestinaciju(Destinacije destinacija)
        {
            using (ProbnaAgencijaEntities1 dbEntitet = new ProbnaAgencijaEntities1())
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
            using (ProbnaAgencijaEntities1 dbEntitet = new ProbnaAgencijaEntities1())
            {
                try
                {
                    dbEntitet.Hotelis.Add(hotel);
                    dbEntitet.SaveChanges();
                }
                catch (Exception) { }
            }
        }



        //MAJA

        public static List<AranzmanViewModel> PrikaziAranzmane()
        {
            using (ProbnaAgencijaEntities1 db = new ProbnaAgencijaEntities1())
            {
                List<AranzmanViewModel> aranzmani = (from a in db.Aranzmanis
                                                     select new AranzmanViewModel { SifraAranzmana = a.AranzmanID, NazivHotela = a.Hoteli.Naziv, VrstaUsluge = a.Usluge.VrstaUsluge, TerminPutovanja = a.Termini.Pocetak.ToString() + " do " + a.Termini.Kraj.ToString(), Cena = a.Cena, Rapolozivost = a.Raspolozivost, Aktivan = a.Aktivan }).ToList();
                return aranzmani;
            }
        }

        public static SelectList PopuniHotele()
        {
            ProbnaAgencijaEntities1 dbEntitet = new ProbnaAgencijaEntities1();
            IEnumerable<SelectListItem> hoteli = (from h in dbEntitet.Hotelis select h).AsEnumerable().Select(h => new SelectListItem()
            { Text = h.Naziv + " , " + h.Destinacije.Grad, Value = h.HotelID.ToString() });
            return new SelectList(hoteli, "Value", "Text", Sifra);
        }


        public static SelectList PopuniUsluge()
        {
            ProbnaAgencijaEntities1 dbEntitet = new ProbnaAgencijaEntities1();
            IEnumerable<SelectListItem> usluge = (from u in dbEntitet.Usluges select u).AsEnumerable().Select(u => new SelectListItem()
            { Text = u.VrstaUsluge, Value = u.UslugaID.ToString() });
            return new SelectList(usluge, "Value", "Text", Sifra);
        }


        public static SelectList PopuniTermine()
        {
            ProbnaAgencijaEntities1 dbEntitet = new ProbnaAgencijaEntities1();
            IEnumerable<SelectListItem> termini = (from t in dbEntitet.Terminis select t).AsEnumerable().Select(t => new SelectListItem()
            { Text = t.Pocetak.ToString() + " do " + t.Kraj.ToString(), Value = t.TerminID.ToString() });
            return new SelectList(termini, "Value", "Text", Sifra);
        }

        public static void DodajAranzman(Aranzmani aranzman)
        {
            using (ProbnaAgencijaEntities1 dbEntitet = new ProbnaAgencijaEntities1())
            {
                try
                {
                    dbEntitet.Aranzmanis.Add(aranzman);
                    dbEntitet.SaveChanges();
                }

                catch (Exception e) { }
            }
        }


        //BRANISLAVA
       
        //public static AranzmanViewModel PrikaziAranzmanPoSifri(int sifra)
        //{
        //    using (ProbnaAgencijaEntities1 db = new ProbnaAgencijaEntities1())
        //    {
        //        AranzmanViewModel aranzman = (from a in db.Aranzmanis where a.AranzmanID == sifra
        //                                      select new AranzmanViewModel { SifraAranzmana = a.AranzmanID, NazivHotela = a.Hoteli.Naziv, VrstaUsluge = a.Usluge.VrstaUsluge, TerminPutovanja = a.Termini.Pocetak.ToString() + " do " + a.Termini.Kraj.ToString(), Cena = a.Cena, Rapolozivost = a.Raspolozivost, Aktivan = a.Aktivan }).Single();
        //        return aranzman;
        //    }

        //}
        public static AranzmanViewModel PrikaziAranzmanPoSifri(int sifra)
        {
            using (ProbnaAgencijaEntities1 db = new ProbnaAgencijaEntities1())
            {
                AranzmanViewModel aranzman = null;

                try
                {
                    aranzman = (from a in db.Aranzmanis
                                where a.AranzmanID == sifra
                                select new AranzmanViewModel { SifraAranzmana = a.AranzmanID, NazivHotela = a.Hoteli.Naziv, VrstaUsluge = a.Usluge.VrstaUsluge, TerminPutovanja = a.Termini.Pocetak.ToString() + " do " + a.Termini.Kraj.ToString(), Cena = a.Cena, Rapolozivost = a.Raspolozivost, Aktivan = a.Aktivan }).Single();
                }
                catch (InvalidOperationException ex)
                {
                    return null;
                }
                return aranzman;
            }
        }
        

        public static void ObrisiAranzmanPoSifri(int sifra)
        {
            ProbnaAgencijaEntities1 dbEntitet = new ProbnaAgencijaEntities1();
            try
            {
                Aranzmani aranzman = (from a in dbEntitet.Aranzmanis where a.AranzmanID == sifra select a).Single();

                aranzman.Aktivan = 0;
                dbEntitet.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        public static void IzmeniAranzman(Aranzmani aranzman)
        {
            using (ProbnaAgencijaEntities1 dbEntitet = new ProbnaAgencijaEntities1())
            {

                Aranzmani izmena = (from a in dbEntitet.Aranzmanis
                                    where a.AranzmanID == aranzman.AranzmanID
                                    select a).Single();

                izmena.Cena = aranzman.Cena; ;
                izmena.Raspolozivost = aranzman.Raspolozivost;
                izmena.Aktivan = aranzman.Aktivan;
                
                try
                {
                    dbEntitet.SaveChanges();
                }
                catch (Exception)
                {

                }
            }
        }
    }
}