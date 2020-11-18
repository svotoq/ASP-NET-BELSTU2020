using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactLibSQL
{
    public class Contact
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public Contact() { }
    }
}
