using CMSApp.Models.DataAccessLayer.Factory;
using CMSApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace CMSApp.Controllers
{
    public class ContactsController : ApiController
    {
        const string hardCodedInitialCatalog = "CMSApp.Models.DataAccessLayer.ContactContext";
        private readonly IContactService contactService;
        public ContactsController(IContactService contactService)
        {
            this.contactService = contactService;
        }
        // GET api/<controller>
        [HttpGet]
        public async Task<IHttpActionResult> GetAllContacts()
        {
            using (var context = new ContextFactory().CreateContext(hardCodedInitialCatalog))
            using (var cancellationTokenSource = new CancellationTokenSource())
            {
                var contacts = await this.contactService.GetAllContactsAsync(context, cancellationTokenSource.Token);
                return Ok(contacts);
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}