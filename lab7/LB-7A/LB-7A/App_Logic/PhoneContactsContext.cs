using System.Data.Entity;
using LB_7A.Models;

namespace LB_7A.App_Logic
{
    public class PhoneContactsContext : DbContext
    {
        public DbSet<PhoneContact> PhoneContacts { get; set; }

        public PhoneContactsContext() : base("ContactsContext") { }
    }
}