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
    public class WyplatasController : Controller
    {
        private db4e37397b7458442a8c4ea6b801845440Entities1 db = new db4e37397b7458442a8c4ea6b801845440Entities1();

        // GET: Wyplatas
        public ActionResult Index(int? id)
        {
            if (Session["Uprawnienia"] != null)
            {
                var list = Session["Uprawnienia"] as List<UzytkownikModels>;
                if (list.Select(p => p.uprawnienia).First() == 2)
                {
                    var wyplata = db.Wyplata.Include(w => w.Table).Where(w => w.IdPracownika == id);
                    return View(wyplata.ToList());
                }
                else
                    return View("../Home/Index");
            }
            else
                return View("../Home/Index");
        }

        // GET: Wyplatas/Details/5
     /*   public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wyplata wyplata = db.Wyplata.Find(id);
            if (wyplata == null)
            {
                return HttpNotFound();
            }
            return View(wyplata);
        }
         */
        // GET: Wyplatas/Create
    /*    public ActionResult Create()
        {
            ViewBag.IdPracownika = new SelectList(db.Table, "IdUzytkownika", "Imie");
            return View();
        } */

        // POST: Wyplatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
     /*   [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdWyplata,Zus,Dochodowy,Data,PlacaNetto,IdPracownika,Emerytalna,rentowa,chorobowa")] Wyplata wyplata)
        {
            if (ModelState.IsValid)
            {
                db.Wyplata.Add(wyplata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPracownika = new SelectList(db.Table, "IdUzytkownika", "Imie", wyplata.IdPracownika);
            return View(wyplata); 
        } */

        // GET: Wyplatas/Edit/5
     /*   public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wyplata wyplata = db.Wyplata.Find(id);
            if (wyplata == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPracownika = new SelectList(db.Table, "IdUzytkownika", "Imie", wyplata.IdPracownika);
            return View(wyplata);
        } */

        // POST: Wyplatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdWyplata,Zus,Dochodowy,Data,PlacaNetto,IdPracownika,Emerytalna,rentowa,chorobowa")] Wyplata wyplata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wyplata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPracownika = new SelectList(db.Table, "IdUzytkownika", "Imie", wyplata.IdPracownika);
            return View(wyplata);
        } */

        // GET: Wyplatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Uprawnienia"] != null)
            {
                var list = Session["Uprawnienia"] as List<UzytkownikModels>;
                if (list.Select(p => p.uprawnienia).First() == 2)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Wyplata wyplata = db.Wyplata.Find(id);
                    if (wyplata == null)
                    {
                        return HttpNotFound();
                    }
                    return View(wyplata);
                }
                else
                    return View("../Home/Index");
           }
            else
                return View("../Home/Index");
        }

        // POST: Wyplatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["Uprawnienia"] != null)
            {
                var list = Session["Uprawnienia"] as List<UzytkownikModels>;
                if (list.Select(p => p.uprawnienia).First() == 2)
                {
                    Wyplata wyplata = db.Wyplata.Find(id);
                    int? id2 = wyplata.IdPracownika;
                    db.Wyplata.Remove(wyplata);
                    db.SaveChanges();
                    return RedirectToAction("Index", new { id = id2 });
                }
                else
                    return View("../Home/Index");
            }
            else
                return View("../Home/Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
