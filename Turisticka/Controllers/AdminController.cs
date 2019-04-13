using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turisticka.Models;

namespace Turisticka.Controllers
{
    public class AdminController : Controller
    {
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

    }
}