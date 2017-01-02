using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DodajWyplateController : Controller
    {
        // GET: DodajWyplate
        public ActionResult Index(int? id)
        {
            double wyplataBrutto;
            if (Session["Uprawnienia"] != null)
            {
                var list = Session["Uprawnienia"] as List<UzytkownikModels>;
                if (list.Select(p => p.uprawnienia).First() == 2)
                {
                    int id2;
                    Wyplata wyplata = new Wyplata();
                    Table uzytkownik = new Table();
                    db4e37397b7458442a8c4ea6b801845440Entities1 db = new db4e37397b7458442a8c4ea6b801845440Entities1();
                    wyplataBrutto = db.Table.Where(p => p.IdUzytkownika == id).Select(p => p.WyplataBrutto).First().Value;
                    if (db.Wyplata.Any())
                    {
                        id2 = db.Wyplata.OrderByDescending(p => p.IdWyplata).Select(p => p.IdWyplata).First();
                        
                        wyplata.IdWyplata = id2 + 1;
                        wyplata.IdPracownika = id;
                        wyplata.Emerytalna = wyplataBrutto * 0.0976;
                        wyplata.chorobowa = wyplataBrutto * 0.0245;
                        wyplata.rentowa = wyplataBrutto * 0.015;
                        wyplata.Zus = wyplataBrutto * 0.09;
                        wyplata.Dochodowy = (wyplataBrutto - ((wyplataBrutto * 0.09) + (wyplataBrutto * 0.0976) + (wyplataBrutto * 0.015) + (wyplataBrutto * 0.0245))) * 0.18;
                        wyplata.PlacaNetto = wyplataBrutto - wyplata.rentowa - wyplata.chorobowa - wyplata.Emerytalna - wyplata.Dochodowy;
                        wyplata.Data = DateTime.Now.Date;
                        db.Wyplata.Add(wyplata);
                        db.SaveChanges();

                    }
                    else
                    {
                        wyplata.IdWyplata = 1;
                        wyplata.IdPracownika = id;
                        wyplata.Emerytalna = wyplataBrutto * 0.0976;
                        wyplata.chorobowa = wyplataBrutto * 0.0245;
                        wyplata.rentowa = wyplataBrutto * 0.015;
                        wyplata.Zus = wyplataBrutto * 0.09;
                        wyplata.Dochodowy = (wyplataBrutto - ((wyplataBrutto * 0.09) + (wyplataBrutto * 0.0976) + (wyplataBrutto * 0.015) + (wyplataBrutto * 0.0245))) * 0.18;
                        wyplata.PlacaNetto = wyplataBrutto - wyplata.rentowa - wyplata.chorobowa - wyplata.Emerytalna - wyplata.Dochodowy;
                        wyplata.Data = DateTime.Now.Date;
                        db.Wyplata.Add(wyplata);
                        db.SaveChanges();

                    }
                    TempData["Wyplata"] = "Dodano wyplate";
                }
                else
                    return View("../Home/Index");
            }
            else
                return View("../Home/Index");
        return RedirectToAction("Index", "EdycjaAdmin");
        }
    }
}