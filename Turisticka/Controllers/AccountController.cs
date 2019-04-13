using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;  //dodato
using MajaIvana.Models;  //dodato


namespace MajaIvana.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult LoginView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginView(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool result = FormsAuthentication.Authenticate(model.KorisnickoIme, model.Lozinka);
            if (!result)
            {
                return View();
            }
            FormsAuthentication.SetAuthCookie(model.KorisnickoIme, false);
            return RedirectToAction("AdminMainView", "Admin");
        }

        //metoda za logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("AdminMainView", "Admin");
        }
    }
}
