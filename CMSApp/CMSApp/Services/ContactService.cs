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
    }
}