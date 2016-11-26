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
     /*   public ActionResult Rejestracja(AspNetUser user)
        {
            //return View();
            if (ModelState.IsValid)
            {
                //List<AspNetUsers> userDod = new List<AspNetUsers>();
                //  userDod.Insert(new AspNetUsers {Name = use.Imie, Nazwisko = model.Nazwisko, Miasto = model.Miasto, KodPocztowy = model.KodPocztowy, Adres = model.Adres, Email = model.Email, Telefon = model.Telefon });
                Entities2 db = new Entities2();
                if (db.AspNetUsers.Any())
                {
                    int id = db.AspNetUsers.OrderByDescending(p => p.Id).Select(p => p.Id).First();
                        //user.Id = userr + 1;
                        //var update = dc.UserProfile.First(d => d.UserName == User.Identity.Name);
                        //var upadte = db.AspNetUserss.First(d => d.Email == "test");
                        //   var update2 = db.AspNetUsers.First(d => d.Confirm == 0);
                        //     update2.Email = "test2";
                        user.Id = id + 1;
                }
                else
                    user.Id = 1;
                db.AspNetUsers.Add(user);
                db.SaveChanges();
            }
            ViewBag.Message = user.Name + "  " + user.Surname + " zarejestrowano poprawnie";
            return View();
        }  */
    }
}