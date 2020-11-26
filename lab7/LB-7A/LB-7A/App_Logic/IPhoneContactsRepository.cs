using System.Collections.Generic;
using System.Threading.Tasks;
using LB_7A.Models;

namespace LB_7A.App_Logic
{
    public interface IPhoneContactsRepository
    {
        Task<List<PhoneContact>> GetContacts();
        Task<PhoneContact> AddContact(PhoneContact phoneContact);
        Task<PhoneContact> UpdatePhoneContact(PhoneContact phoneContact);
        Task RemoveContact(int id);
    }
}
