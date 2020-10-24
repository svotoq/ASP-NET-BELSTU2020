using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Lab2.Models
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
    }
}
