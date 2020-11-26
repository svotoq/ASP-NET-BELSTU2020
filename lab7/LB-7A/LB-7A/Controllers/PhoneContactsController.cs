using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LB_7A.App_Logic;
using LB_7A.Models;

namespace LB_7A.Controllers
{
    [RoutePrefix("ts")]
    public class PhoneContactsController : ApiController
    {
        private readonly IPhoneContactsRepository _phoneContactsRepository;

        public PhoneContactsController()
        {
            _phoneContactsRepository = new PhoneContactsRepository();
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetContacts()
        {
            var contacts = await _phoneContactsRepository.GetContacts();

            return Ok(contacts);
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> AddContact([FromBody]PhoneContact phoneContact)
        {
            var addedContact = await _phoneContactsRepository.AddContact(phoneContact);

            return Ok(addedContact);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> UpdateContact([FromBody]PhoneContact phoneContact)
        {
            var updatedContact = await _phoneContactsRepository.UpdatePhoneContact(phoneContact);

            return Ok(updatedContact);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<HttpResponseMessage> DeleteContact(int id)
        {
            await _phoneContactsRepository.RemoveContact(id);

            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
