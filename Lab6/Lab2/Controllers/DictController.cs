using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContactLib;
//using ContactLibSQL;
namespace Lab2.Controllers
{
    public class DictController : Controller
    {
        private IContactContext<Contact> db = null;
        public DictController(IContactContext<Contact> db)
        {
            this.db = db;
        }
        // GET: Dict
        public ActionResult Index()
        {
            return View(db.GetConList());
        }

        // GET: Dict/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.GetContact(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Dict/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dict/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Surname,PhoneNumber")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Add(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Dict/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.GetContact(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Dict/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Surname,PhoneNumber")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Update(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Dict/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.GetContact(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Dict/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
