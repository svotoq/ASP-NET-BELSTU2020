using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using LB_7A.Models;

namespace LB_7A.App_Logic
{
    public class PhoneContactsRepository : IPhoneContactsRepository
    {
        private readonly PhoneContactsContext _phoneContactsContext;

        public PhoneContactsRepository()
        {
            _phoneContactsContext = new PhoneContactsContext();
        }

        public async Task<List<PhoneContact>> GetContacts()
        {
            return await _phoneContactsContext.PhoneContacts.AsNoTracking().ToListAsync();
        }

        public async Task<PhoneContact> AddContact(PhoneContact phoneContact)
        {
            _phoneContactsContext.PhoneContacts.Add(phoneContact);

            await _phoneContactsContext.SaveChangesAsync();

            return phoneContact;
        }

        public async Task<PhoneContact> UpdatePhoneContact(PhoneContact phoneContact)
        {
            _phoneContactsContext.Entry(phoneContact).State = EntityState.Modified;

            await _phoneContactsContext.SaveChangesAsync();

            return phoneContact;
        }

        public async Task RemoveContact(int id)
        {
            var removableContact = await _phoneContactsContext.PhoneContacts.FirstOrDefaultAsync(x => x.Id == id);
            if (removableContact != null)
            {
                _phoneContactsContext.PhoneContacts.Remove(removableContact);
            }

            await _phoneContactsContext.SaveChangesAsync();
        }
    }
}