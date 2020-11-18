using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace ContactLib
{
    public class ContactContext : IContactContext<Contact>
    {
        private string FILE_NAME = HostingEnvironment.MapPath("~/Models/Data.json");
        public List<Contact> GetConList()
        {
            if (!File.Exists(FILE_NAME))
            {
                return new List<Contact>();
            }
            List<Contact> contacts = null;
            using (StreamReader sr = new StreamReader(FILE_NAME))
            {
                JsonTextReader jsonTextReader = new JsonTextReader(sr);
                JsonSerializer jsonSerializer = new JsonSerializer();
                contacts = jsonSerializer.Deserialize<List<Contact>>(jsonTextReader);
            }
            if (contacts == null)
            {
                contacts = new List<Contact>();
            }
            return contacts;
        }

        public Contact GetContact(int? id)
        {
            var contacts = GetConList();
            var contact = contacts.FirstOrDefault(p => p.Id.Equals(id));
            return contact;
        }
      
        private void Save(List<Contact> contacts)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(FILE_NAME))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, contacts);
            }
        }

        public void Add(Contact contact)
        {
            var contacts = GetConList();
            var lastId = 0;
            if (contacts.Count() > 0)
            {
                lastId = contacts.LastOrDefault().Id;
            }
            contact.Id = ++lastId;
            contacts.Add(contact);
            Save(contacts);
        }

        public void Delete(int? id)
        {
            var contacts = GetConList();
            Contact contact = contacts.FirstOrDefault(con => con.Id == id);
            if (contact != null)
            {
                contacts.Remove(contact);
                Save(contacts);
            }
        }

        public void Update(Contact contact)
        {
            var contacts = GetConList();
            Contact oldContact = contacts.FirstOrDefault(con => con.Id == contact.Id);
            oldContact.Surname = contact.Surname;
            oldContact.PhoneNumber = contact.PhoneNumber;
            Save(contacts);
        }
    }
}
