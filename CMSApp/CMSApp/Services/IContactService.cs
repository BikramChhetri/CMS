using CMSApp.Models;
using CMSApp.Models.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMSApp.Services
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllContactsAsync(ContactContext context, CancellationToken cancellationToken);
        Task<int> AddContactAsync(ContactContext context, Contact contact, CancellationToken cancellationToken);
        Task<Contact> GetContactByIdAsync(ContactContext context, int contactId, CancellationToken cancellationToken);
        Task<int> UpdateContactAsync(ContactContext context, Contact contact, CancellationToken cancellationToken);
        Task<int> DeleteContactAsync(ContactContext context, int contactId, string setStatusTo, CancellationToken cancellationToken);
    }
}
