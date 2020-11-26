using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LB_7C.Model;
using Newtonsoft.Json;

namespace LB_7C.ServiceHandler
{
    public class PhoneContactService : IPhoneContactService
    {
        private string _filePath = @"D:\myFolder\asp.net\lab7\LB-7C\LB-7C\contacts.json";

        private static IList<PhoneContact> _phoneContacts;

        public PhoneContactService()
        {
            _phoneContacts = ReadContacts();
        }

        public List<PhoneContact> GetPhoneContacts()
        {
            return _phoneContacts.ToList();
        }

        public List<PhoneContact> AddPhoneContact(PhoneContact phoneContact)
        {
            var maxId = _phoneContacts.Count > 0 ? _phoneContacts.Max(x => x.Id) : 0;
            phoneContact.Id = maxId + 1;

            _phoneContacts.Add(phoneContact);
            SaveChanges();

            return _phoneContacts.ToList();
        }

        public List<PhoneContact> UpdatePhoneContact(PhoneContact phoneContact)
        {
            var existingContact = _phoneContacts.First(x => x.Id == phoneContact.Id);

            existingContact.Name = phoneContact.Name;
            existingContact.Phone = phoneContact.Phone;

            SaveChanges();

            return _phoneContacts.ToList();
        }

        public List<PhoneContact> RemovePhoneContact(int phoneContactId)
        {
            _phoneContacts.Remove(_phoneContacts.First(x => x.Id == phoneContactId));

            return _phoneContacts.ToList();
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
