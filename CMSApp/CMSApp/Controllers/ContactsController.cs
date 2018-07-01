using CMSApp.Models;
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
        //const string hardCodedInitialCatalog = "CMSApp.Models.DataAccessLayer.ContactContext";
        const string hardCodedInitialCatalog = "ContactDB";
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
        [HttpGet]
        public async Task<IHttpActionResult> GetContact(int id)
        {
            using (var context = new ContextFactory().CreateContext(hardCodedInitialCatalog))
            using (var cancellationTokenSource = new CancellationTokenSource())
            {
                var contact = await this.contactService.GetContactByIdAsync(context, id, cancellationTokenSource.Token);
                return Ok(contact);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]Contact contact)
        {
            using (var context = new ContextFactory().CreateContext(hardCodedInitialCatalog))
            using (var cancellationTokenSource = new CancellationTokenSource())
            {
                var result = await this.contactService.AddContactAsync(context, contact, cancellationTokenSource.Token);
                return Ok();
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody]Contact contact)
        {
            using (var context = new ContextFactory().CreateContext(hardCodedInitialCatalog))
            using (var cancellationTokenSource = new CancellationTokenSource())
            {
                await this.contactService.UpdateContactAsync(context, contact, cancellationTokenSource.Token);
                return Ok();
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id, string setStatusTo)
        {
            using (var context = new ContextFactory().CreateContext(hardCodedInitialCatalog))
            using (var cancellationTokenSource = new CancellationTokenSource())
            {
                await this.contactService.DeleteContactAsync(context, id, setStatusTo, cancellationTokenSource.Token);
                return Ok();
            }
        }
    }
}