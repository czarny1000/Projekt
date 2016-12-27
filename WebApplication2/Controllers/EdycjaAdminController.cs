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
    public class EdycjaAdminController : Controller
    {
        private db4e37397b7458442a8c4ea6b801845440Entities1 db = new db4e37397b7458442a8c4ea6b801845440Entities1();
        // GET: EdycjaAdmin
        
        public ActionResult Index()
        {
            if (Session["Uprawnienia"] != null)
            {
                var list = Session["Uprawnienia"] as List<UzytkownikModels>;
                if (list.Select(p => p.uprawnienia).First() == 2)
                {
                    return View(db.Table.ToList());
                }
                else
                    return View("../Home/Index");
            }
            else
                return View("../Home/Index");
        }

        // GET: EdycjaAdmin/Details/5
        public ActionResult Details(int? id)
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
                    Table table = db.Table.Find(id);
                    if (table == null)
                    {
                        return HttpNotFound();
                    }
                    return View(table);
                }
                else
                    return View("../Home/Index");
            }
            else
                return View("../Home/Index");
        }

        // GET: EdycjaAdmin/Create
        public ActionResult Create()
        {
            if (Session["Uprawnienia"] != null)
            {
                var list = Session["Uprawnienia"] as List<UzytkownikModels>;
                if (list.Select(p => p.uprawnienia).First() == 2)
                {
                    return View();
                }
                else
                    return View("../Home/Index");
            }
            else
                return View("../Home/Index");
        }

        // POST: EdycjaAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUzytkownika,Imie,Nazwisko,Data_Urodzenia,Pesel,Dzial,WyplataBrutto,Uprawnienia,Haslo,benefit,potwierdzenie,login")] Table table)
        {
            if (Session["Uprawnienia"] != null)
            {
                var list = Session["Uprawnienia"] as List<UzytkownikModels>;
                if (list.Select(p => p.uprawnienia).First() == 2)
                {
                    if (ModelState.IsValid)
                    {
                        db.Table.Add(table);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    return View(table);
                }
                else
                    return View("../Homde/Index");
            }
            else
                return View("../Home/Index");
        }

        // GET: EdycjaAdmin/Edit/5
        public ActionResult Edit(int? id)
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
                    Table table = db.Table.Find(id);
                    if (table == null)
                    {
                        return HttpNotFound();
                    }
                    return View(table);
                }
                else
                    return View("../Home/Index");
            }
            else
                return View("../Home/Index");
        }

        // POST: EdycjaAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUzytkownika,Imie,Nazwisko,Data_Urodzenia,Pesel,Dzial,WyplataBrutto,Uprawnienia,Haslo,benefit,potwierdzenie,login")] Table table)
        {
            if (Session["Uprawnienia"] != null)
            {
                var list = Session["Uprawnienia"] as List<UzytkownikModels>;
                if (list.Select(p => p.uprawnienia).First() == 2)
                {
                    if (ModelState.IsValid)
                    {
                        db.Entry(table).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    return View(table);
                }
                else
                    return View("../Home/Index");
            }
            else
                return View("../Home/Index");
        }

        // GET: EdycjaAdmin/Delete/5
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
                    Table table = db.Table.Find(id);
                    if (table == null)
                    {
                        return HttpNotFound();
                    }
                    return View(table);
                }
                else
                    return View("../Home/Index");
            }
            else
                return View("../Home/Index");
        }

        // POST: EdycjaAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["Uprawnienia"] != null)
            {
                var list = Session["Uprawnienia"] as List<UzytkownikModels>;
                if (list.Select(p => p.uprawnienia).First() == 2)
                {
                    Table table = db.Table.Find(id);
                    db.Table.Remove(table);
                    db.SaveChanges();
                    return RedirectToAction("Index");
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
