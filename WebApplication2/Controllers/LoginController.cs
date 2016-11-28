using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Logowanie");
        }
        public ActionResult Login(LogowanieModels user)
        {
            int id2;
            if (ModelState.IsValid)
            {
                db4e37397b7458442a8c4ea6b801845440Entities1 db = new db4e37397b7458442a8c4ea6b801845440Entities1();
                try
                {
                    id2 = db.Table.OrderByDescending(p => p.IdUzytkownika).Where(p => p.login == user.Login && p.Haslo == user.Haslo).Select(p => p.IdUzytkownika).First();
                    int uprawnienia2 = db.Table.OrderByDescending(p => p.IdUzytkownika).Where(p => p.IdUzytkownika == id2).Select(p => p.Uprawnienia).First().Value;
                    List<UzytkownikModels> uzytkownik = new List<UzytkownikModels>(); // tworzenie nowej listy opartej na modelu Koszyk
                    int licznik = uzytkownik.Count;
                    uzytkownik.Insert(licznik, new UzytkownikModels {Id = id2, uprawnienia = uprawnienia2 });
                    Session["Login"] = user.Login;
                    Session["Uzytkownik"] = uzytkownik;
                    TempData["login"] = "Zalogowano Poprawnie";
                }
                catch
                {
                    TempData["login"] = "bledny login lub haslo";
                }
            }
            
            return View();

        }
    }
}