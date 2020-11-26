using System.Collections.Generic;
using System.ServiceModel;
using LB_7C.Model;

namespace LB_7C.ServiceHandler
{
    [ServiceContract]
    public interface IPhoneContactService
    {
        [OperationContract]
        List<PhoneContact> GetPhoneContacts();

        [OperationContract]
        List<PhoneContact> AddPhoneContact(PhoneContact phoneContact);

        [OperationContract]
        List<PhoneContact> UpdatePhoneContact(PhoneContact phoneContact);

        [OperationContract]
        List<PhoneContact> RemovePhoneContact(int phoneContactId);
    }
}
