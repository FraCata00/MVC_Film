using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Film.Models;

namespace MVC_Film.Views
{
    public class AbbonamentoController : Controller
    {
        private Cloud_FilmEntities db = new Cloud_FilmEntities();

        // GET: Abbonamento
        public ActionResult Index()
        {
            var abbonamento = db.Abbonamento.Include(a => a.Account).Include(a => a.MetodoPagamento);
            return View(abbonamento.ToList());
        }

        // GET: Abbonamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abbonamento abbonamento = db.Abbonamento.Find(id);
            if (abbonamento == null)
            {
                return HttpNotFound();
            }
            return View(abbonamento);
        }

        // GET: Abbonamento/Create
        public ActionResult Create()
        {
            ViewBag.IdAccount = new SelectList(db.Account, "ID", "Email");
            ViewBag.IdMetodoPagamento = new SelectList(db.MetodoPagamento, "ID", "PayPal");
            return View();
        }

        // POST: Abbonamento/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IdAccount,IdMetodoPagamento,GiorniAbbonamento")] Abbonamento abbonamento)
        {
            if (ModelState.IsValid)
            {
                db.Abbonamento.Add(abbonamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAccount = new SelectList(db.Account, "ID", "Email", abbonamento.IdAccount);
            ViewBag.IdMetodoPagamento = new SelectList(db.MetodoPagamento, "ID", "PayPal", abbonamento.IdMetodoPagamento);
            return View(abbonamento);
        }

        // GET: Abbonamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abbonamento abbonamento = db.Abbonamento.Find(id);
            if (abbonamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAccount = new SelectList(db.Account, "ID", "Email", abbonamento.IdAccount);
            ViewBag.IdMetodoPagamento = new SelectList(db.MetodoPagamento, "ID", "PayPal", abbonamento.IdMetodoPagamento);
            return View(abbonamento);
        }

        // POST: Abbonamento/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IdAccount,IdMetodoPagamento,GiorniAbbonamento")] Abbonamento abbonamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abbonamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAccount = new SelectList(db.Account, "ID", "Email", abbonamento.IdAccount);
            ViewBag.IdMetodoPagamento = new SelectList(db.MetodoPagamento, "ID", "PayPal", abbonamento.IdMetodoPagamento);
            return View(abbonamento);
        }

        // GET: Abbonamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abbonamento abbonamento = db.Abbonamento.Find(id);
            if (abbonamento == null)
            {
                return HttpNotFound();
            }
            return View(abbonamento);
        }

        // POST: Abbonamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Abbonamento abbonamento = db.Abbonamento.Find(id);
            db.Abbonamento.Remove(abbonamento);
            db.SaveChanges();
            return RedirectToAction("Index");
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
