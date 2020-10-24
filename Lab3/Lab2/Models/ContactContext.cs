using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Lab2.Models
{
    public class ContactContext
    {
        private string FILE_NAME = HostingEnvironment.MapPath("~/Models/Data.json");
        public List<Contact> contacts { get; private set; }
        public ContactContext()
        {
            Load();
        }
        private void Load()
        {
            if (!File.Exists(FILE_NAME))
            {
                return;
            }
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
        }
        private void Save()
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
            var lastId = 0;
            if (contacts.Count() > 0)
            {
                lastId = contacts.LastOrDefault().Id;
            }
            contact.Id = ++lastId;
            contacts.Add(contact);
            Save();
        }

        public void Delete(int id)
        {
            Contact contact = contacts.FirstOrDefault(con => con.Id == id);
            if (contact != null)
            {
                contacts.Remove(contact);
                Save();
            }
        }

        public void Update(int id, string surname, string phoneNumber)
        {
            Contact contact = contacts.FirstOrDefault(con => con.Id == id);
            contact.Surname = surname;
            contact.PhoneNumber = phoneNumber;
            Save();
        }

    }
}