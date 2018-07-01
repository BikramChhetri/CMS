using CMSApp.Models;
using CMSApp.Models.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace CMSApp.Services
{
    public class ContactService : IContactService
    {
        public async Task<List<Contact>> GetAllContactsAsync(ContactContext context, CancellationToken cancellationToken)
        {
            return await context.Contacts.ToListAsync();
        }
        public async Task<int> AddContactAsync(ContactContext context, Contact contact, CancellationToken cancellationToken)
        {
            context.Contacts.Add(contact);
            return await context.SaveChangesAsync(cancellationToken);

        }
        public async Task<Contact> GetContactByIdAsync(ContactContext context, int contactId, CancellationToken cancellationToken)
        {
            var contact = await context.Contacts.FirstOrDefaultAsync(c => c.Id == contactId, cancellationToken);
            return contact;
        }
        public async Task<int> UpdateContactAsync(ContactContext context, Contact contact, CancellationToken cancellationToken)
        {
            context.Entry(contact).State = EntityState.Modified;
            return await context.SaveChangesAsync(cancellationToken);
        }
        public async Task<int> DeleteContactAsync(ContactContext context, int contactId, string setStatusTo, CancellationToken cancellationToken)
        {
            var contact = context.Contacts.FirstOrDefaultAsync(c => c.Id == contactId, cancellationToken).Result;
            if (contact.Status.ToString() != setStatusTo)
            {
                contact.Status = (Status)Enum.Parse(typeof(Status), setStatusTo);
                context.Entry(contact).State = EntityState.Modified;
            }
            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}