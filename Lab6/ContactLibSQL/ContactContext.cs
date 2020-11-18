using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactLibSQL
{
    public class ContactContext : IContactContext<Contact>
    {
        public List<Contact> GetConList()
        {
            using (AppContext db = new AppContext())
            {
                List<Contact> contacts = db.Contacts.OrderBy(p => p.Surname).ToList();
                return contacts;
            }
        }

        public Contact GetContact(int? id)
        {
            Contact contact;
            using (AppContext db = new AppContext())
            {
                contact = db.Contacts.Find(id);
                return contact;
            }
        }

        public void Add(Contact item)
        {
            using (AppContext db = new AppContext())
            {
                db.Contacts.Add(item);
                db.SaveChanges();
            }
        }

        public void Delete(int? id)
        {
            using (AppContext db = new AppContext())
            {
                Contact contact = db.Contacts.Where(p => p.Id.Equals(id)).FirstOrDefault();
                db.Contacts.Remove(contact);
                db.SaveChanges();
            }
        }

        public void Update(Contact item)
        {
            using (AppContext db = new AppContext())
            {
                var contact = db.Contacts.Find(item.Id);
                contact.PhoneNumber = item.PhoneNumber;
                contact.Surname = item.Surname;
                db.Entry<Contact>(contact).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
