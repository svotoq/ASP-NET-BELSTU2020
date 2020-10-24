using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class DictController : Controller
    {
        ContactContext contactContext = new ContactContext();
        public ActionResult Index()
        {
            ViewBag.Contacts = contactContext.contacts;
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSave(string surname, string telephone)
        {
            contactContext.Add(new Contact(surname, telephone));
            ViewBag.Contacts = contactContext.contacts;
            return View("Index");
        }
        [HttpGet]
        public ActionResult Update(string selectedItemId)
        {
            Contact contact = contactContext.contacts.FirstOrDefault(cont => cont.Id == Convert.ToInt32(selectedItemId));
            ViewBag.Contact = contact;
            return View();
        }
        [HttpPost]
        public ActionResult UpdateSave(string id, string surname, string telephone)
        {
            contactContext.Update(Convert.ToInt32(id), surname, telephone);
            ViewBag.Contacts = contactContext.contacts;
            return View("Index");
        }
        public ActionResult Delete(string selectedItemId)
        {
            ViewBag.Id = selectedItemId;
            return View();
        }
        [HttpPost]
        public ActionResult DeleteSave(string id)
        {
            contactContext.Delete(Convert.ToInt32(id));
            ViewBag.Contacts = contactContext.contacts;
            return View("Index");
        }

    }
}