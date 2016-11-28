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
            return View("Rejestracja");
        }
        // GET: Rejestracja
        public ActionResult Rejestracja(RejestracjaModel user)
        {
            //return View();
            int id = 1;
            if (ModelState.IsValid)
            {
                List<Table> userDod = new List<Table>();
                Table UserDod2 = new Table();
                //  userDod.Insert(new AspNetUsers {Name = use.Imie, Nazwisko = model.Nazwisko, Miasto = model.Miasto, KodPocztowy = model.KodPocztowy, Adres = model.Adres, Email = model.Email, Telefon = model.Telefon });
                db4e37397b7458442a8c4ea6b801845440Entities1 db = new db4e37397b7458442a8c4ea6b801845440Entities1();
                if (db.Table.Any())
                {
                    if ((db.Table.Where(p => p.login == user.login).Any()) == false)
                    {
                        id = db.Table.OrderByDescending(p => p.IdUzytkownika).Select(p => p.IdUzytkownika).First();
                        //userDod.Insert(0,new Table {IdUzytkownika=id + 1,Data_Urodzenia=user.Data_Urodzenia, Imie = user.Imie, Nazwisko = user.Nazwisko, Dzial = user.Dzial, Pesel = user.Dzial, WyplataBrutto = user.WyplataBrutto});
                        //user.Id = userr + 1;
                        //var update = dc.UserProfile.First(d => d.UserName == User.Identity.Name);
                        //var upadte = db.AspNetUserss.First(d => d.Email == "test");
                        //   var update2 = db.AspNetUsers.First(d => d.Confirm == 0);
                        //     update2.Email = "test2";
                        id = id + 1;
                        UserDod2.IdUzytkownika = id;
                        UserDod2.login = user.login;
                        UserDod2.Haslo = user.Haslo;
                        UserDod2.Data_Urodzenia = user.Data_Urodzenia;
                        UserDod2.Imie = user.Imie;
                        UserDod2.Nazwisko = user.Nazwisko;
                        UserDod2.Dzial = user.Dzial;
                        UserDod2.Pesel = user.Pesel;
                        UserDod2.WyplataBrutto = user.WyplataBrutto;
                        db.Table.Add(UserDod2);
                        db.SaveChanges();
                    }
                }
                // userDod.Insert(0, new Table { IdUzytkownika =  1, Data_Urodzenia = user.Data_Urodzenia, Imie = user.Imie, Nazwisko = user.Nazwisko, Dzial = user.Dzial, Pesel = user.Dzial, WyplataBrutto = user.WyplataBrutto });
                else
                {
                    UserDod2.IdUzytkownika = id;
                    UserDod2.login = user.login;
                    UserDod2.Haslo = user.Haslo;
                    UserDod2.Data_Urodzenia = user.Data_Urodzenia;
                    UserDod2.Imie = user.Imie;
                    UserDod2.Nazwisko = user.Nazwisko;
                    UserDod2.Dzial = user.Dzial;
                    UserDod2.Pesel = user.Pesel;
                    UserDod2.WyplataBrutto = user.WyplataBrutto;
                    db.Table.Add(UserDod2);
                    db.SaveChanges();
                }
            }
            TempData["rejestracja"] = user.Imie + "  " + user.Nazwisko + " zarejestrowano poprawnie";
            return View();
        }  
    }
}