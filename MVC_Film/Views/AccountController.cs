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
    public class AccountController : Controller
    {
        private Cloud_FilmEntities db = new Cloud_FilmEntities();

        // GET: Account
        public ActionResult Index()
        {
            var account = db.Account.Include(a => a.Persona);
            return View(account.ToList());
        }

        // GET: Account/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Account.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            ViewBag.idPersona = new SelectList(db.Persona, "CodiceFiscale", "Nome");
            return View();
        }

        // POST: Account/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Email,Password,idPersona")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Account.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPersona = new SelectList(db.Persona, "CodiceFiscale", "Nome", account.idPersona);
            return View(account);
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Account.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPersona = new SelectList(db.Persona, "CodiceFiscale", "Nome", account.idPersona);
            return View(account);
        }

        // POST: Account/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Email,Password,idPersona")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPersona = new SelectList(db.Persona, "CodiceFiscale", "Nome", account.idPersona);
            return View(account);
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Account.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Account.Find(id);
            db.Account.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Login(string email, string password)
        {
            if((email == null)&&(password == null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /*Account account = db.Account.Find(email,password);
            //Account accountPassword = db.Account.Find(password);
            if((account == null))
            {
                return HttpNotFound();
            }*/
            var findEmail = db.Account.Where(x => x.Email.Equals(email));
            var findPassword = db.Account.Where(x => x.Password.Equals(password));
            if ((findEmail == null) && (findPassword == null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var account = db.Account.Where(x => x.Email == email && x.Password == password).ToList();
            if (account == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            return View();
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
