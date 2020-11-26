using System.Collections.Generic;
using System.Web.Services;

namespace LB_7B
{
    [WebService(Namespace = "http://stasyan.by/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ContactsService : WebService
    {
        private readonly ContactsHandler _contactsHandler;

        public ContactsService()
        {
            _contactsHandler = new ContactsHandler();
        }

        [WebMethod(Description = "Get all contacts", EnableSession = true)]
        public List<PhoneContact> GetPhoneContacts()
        {
            return _contactsHandler.GetPhoneContacts();
        }

        [WebMethod(Description = "Add phone contact", EnableSession = true)]
        public List<PhoneContact> AddContact(PhoneContact phoneContact)
        {
            _contactsHandler.AddContact(phoneContact);

            return _contactsHandler.GetPhoneContacts();
        }

        [WebMethod(Description = "Update phone contact", EnableSession = true)]
        public List<PhoneContact> UpdateContact(PhoneContact phoneContact)
        {
            _contactsHandler.UpdateContact(phoneContact);

            return _contactsHandler.GetPhoneContacts();
        }
        [WebMethod(Description = "Remove phone contact", EnableSession = true)]
        public List<PhoneContact> RemoveContact(int id)
        {
            _contactsHandler.RemoveContact(id);

            return _contactsHandler.GetPhoneContacts();
        }
    }
}
