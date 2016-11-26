using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class RejestracjaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        // GET: Rejestracja
        public ActionResult Rejestracja(Table user)
        {
            //return View();
            if (ModelState.IsValid)
            {
                //List<AspNetUsers> userDod = new List<AspNetUsers>();
                //  userDod.Insert(new AspNetUsers {Name = use.Imie, Nazwisko = model.Nazwisko, Miasto = model.Miasto, KodPocztowy = model.KodPocztowy, Adres = model.Adres, Email = model.Email, Telefon = model.Telefon });
                db4e37397b7458442a8c4ea6b801845440Entities1 db = new db4e37397b7458442a8c4ea6b801845440Entities1();
                if (db.Table.Any())
                {
                    int id = db.Table.OrderByDescending(p => p.IdUzytkownika).Select(p => p.IdUzytkownika).First();
                        //user.Id = userr + 1;
                        //var update = dc.UserProfile.First(d => d.UserName == User.Identity.Name);
                        //var upadte = db.AspNetUserss.First(d => d.Email == "test");
                        //   var update2 = db.AspNetUsers.First(d => d.Confirm == 0);
                        //     update2.Email = "test2";
                        user.IdUzytkownika = id + 1;
                }
                else
                    user.IdUzytkownika = 1;
                db.Table.Add(user);
                db.SaveChanges();
            }
            ViewBag.Message = user.Imie + "  " + user.Nazwisko + " zarejestrowano poprawnie";
            return View();
        }  
    }
}