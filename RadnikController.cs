using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;    //dodato
using MajaIvana.Models; //dodato

namespace MajaIvana.Controllers
{
    public class RadnikController : Controller
    {
        // GET: Radnik
        public ActionResult RadnikMainView()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult DodajKorisnika(Korisnici korisnik)
        {
                Radnik.DodajKorisnika(korisnik);
                return RedirectToAction("RadnikMainView");
        }
    }
}