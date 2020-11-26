using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace LB_7B
{
    public class ContactsHandler
    {
        private string _filePath = AppDomain.CurrentDomain.BaseDirectory + "contacts.json";

        private static IList<PhoneContact> _phoneContacts;


        public ContactsHandler()
        {
            _phoneContacts = ReadContacts();
        }

        public List<PhoneContact> GetPhoneContacts()
        {
            return _phoneContacts.ToList();
        }

        public void AddContact(PhoneContact contact)
        {
            var maxId = _phoneContacts.Count > 0 ? _phoneContacts.Max(x => x.Id) : 0;
            contact.Id = maxId + 1;

            _phoneContacts.Add(contact);
            SaveChanges();
        }

        public void UpdateContact(PhoneContact contact)
        {
            var existingContact = _phoneContacts.First(x => x.Id == contact.Id);

            existingContact.Name = contact.Name;
            existingContact.Phone = contact.Phone;

            SaveChanges();
        }

        public void RemoveContact(int id)
        {
            _phoneContacts.Remove(_phoneContacts.First(x => x.Id == id));

            SaveChanges();
        }

        private List<PhoneContact> ReadContacts()
        {
            var jsonString = File.ReadAllText(_filePath);

            if (string.Equals(jsonString, string.Empty, StringComparison.CurrentCultureIgnoreCase))
            {
                return new List<PhoneContact>();
            } 

            return JsonConvert.DeserializeObject<List<PhoneContact>>(jsonString);
        }

        private void SaveChanges() => File.WriteAllText(_filePath, JsonConvert.SerializeObject(_phoneContacts));
    }
}