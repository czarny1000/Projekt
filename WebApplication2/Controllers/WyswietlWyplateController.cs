using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class WyswietlWyplateController : Controller
    {
        private db4e37397b7458442a8c4ea6b801845440Entities1 db = new db4e37397b7458442a8c4ea6b801845440Entities1();

        // GET: WyswietlWyplate
        public ActionResult Index()
        {
            if (Session["Uprawnienia"] != null)
            {
                var list = Session["Uprawnienia"] as List<UzytkownikModels>;
                if (list.Select(p => p.uprawnienia).First() == 1)
                {
                    int id = list.Select(p => p.Id).First();
                    var wyplata = db.Wyplata.Include(w => w.Table).Where(p => p.IdPracownika == id);
                    return View(wyplata.ToList());
                }
                else
                    return View("../Home/Index");
            }
            else
                return View("../Home/Index");
        }
    }
}
