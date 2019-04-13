using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MajaIvana.Models;

namespace MajaIvana.Controllers
{
    public class AdminController : Controller
    {
        //IVANA

        // GET: Admin
        public ActionResult AdminMainView()
        {
            PopuniSifreDestinacija();
            return View();
        }

        private void PopuniSifreDestinacija()
        {
            SelectList items = Admin.PopuniListuDestinacijaID();
            if (items != null)
            {
                ViewBag.destinacije = items;
            }
        }

        [HttpPost]
        public ActionResult DodajDestinaciju(Destinacije destinacija)
        {
            Admin.DodajDestinaciju(destinacija);
            return RedirectToAction("AdminMainView");
        }

        [HttpPost]
        public ActionResult DodajHotel(FormCollection hotel)
        {
            Hoteli nov = new Hoteli();
            nov.HotelID = int.Parse(hotel["HotelID"]);
            nov.DestinacijaID = int.Parse(hotel["listaDestinacijaID"]);
            nov.Naziv = hotel["Naziv"];
            nov.BrojZvezdica = int.Parse(hotel["BrojZvezdica"]);
            Admin.DodajHotel(nov);
            return RedirectToAction("AdminMainView");
        }



        //MAJA

        private void PopuniListuHotela()
        {
            SelectList items = Admin.PopuniHotele();
            if (items != null)
            {
                ViewBag.hoteli = items;
            }
        }

        private void PopuniListuUsluga()
        {
            SelectList items = Admin.PopuniUsluge();
            if (items != null)
            {
                ViewBag.usluge = items;
            }
        }

        private void PopuniListuTermina()
        {
            SelectList items = Admin.PopuniTermine();
            if (items != null)
            {
                ViewBag.termini = items;
            }
        }


        // GET: Admin Aranzmani
        public ActionResult AranzmaniDodajView()
        {
            PopuniListuHotela();
            PopuniListuUsluga();
            PopuniListuTermina();
            return View();
        }

        [HttpPost]

        public ActionResult AranzmaniDodajView(FormCollection aranzman)//vraca onaj deo forme u kojoj je kliknuto na to ime
        {
            PopuniListuHotela();
            PopuniListuUsluga();
            PopuniListuTermina();

            
            Aranzmani novi = new Aranzmani();
            novi.AranzmanID = Convert.ToInt32(aranzman["AranzmanID"]);
            novi.HotelID = Convert.ToInt32(aranzman["listaHotela"]);
            novi.UslugaID = Convert.ToInt32(aranzman["listaUsluga"]);
            novi.TerminID = Convert.ToInt32(aranzman["listaTermina"]);
            novi.Cena = Convert.ToDouble(aranzman["Cena"]);
            novi.Raspolozivost = Convert.ToInt32(aranzman["Raspolozivost"]);
            Admin.DodajAranzman(novi);

            return RedirectToAction("AranzmaniDodajView");
            
        }


        //BRANISLAVA

        [HttpPost]
        public ActionResult AranzmanPrikaziPoSifri(AdminViewModel aranzman)
        {
            AranzmanViewModel prikazi = Admin.PrikaziAranzmanPoSifri(Convert.ToInt32(aranzman.SifraAranzmana));

            return View("AranzmanPrikaziPoSifriView", prikazi);
        }

        [HttpPost]
        public ActionResult AranzmanIzmeniObrisi(FormCollection aranzman, string BtnSubmit)
        {
            //if (ModelState.IsValid)
            //{
            switch (aranzman["BtnSubmit"])
            {
                case "Obriši":
                    {
                        Admin.ObrisiAranzmanPoSifri(int.Parse(aranzman["SifraAranzmana"]));
                        TempData["Sifra"] = Convert.ToInt32(aranzman["SifraAranzmana"]);
                        return RedirectToAction("AdminMainView");
                    }
                case "Izmeni":
                    {
                        Aranzmani nov = new Aranzmani();
                        nov.AranzmanID=Convert.ToInt32(aranzman["SifraAranzmana"]);
                        
                        nov.Cena = Convert.ToDouble(aranzman["Cena"]);
                        nov.Raspolozivost = Convert.ToInt32(aranzman["Rapolozivost"]);
                        nov.Aktivan = Convert.ToInt32(aranzman["Aktivan"]);

                        Admin.IzmeniAranzman(nov);
                        TempData["Izmena"] = Convert.ToInt32(aranzman["SifraAranzmana"]);
                        return View("AdminMainView");
                    }
                default: return View("AdminMainView");
            }
        }
    }
}
    
