using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    [Serializable]
    public class Contact
    {
        public int Id;
        public string Surname;
        public string PhoneNumber;

        public Contact(string surname, string phoneNumber)
        {
            Surname = surname;
            PhoneNumber = phoneNumber;
        }
    }
}