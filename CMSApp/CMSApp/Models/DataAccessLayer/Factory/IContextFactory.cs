using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApp.Models.DataAccessLayer.Factory
{
    public interface IContextFactory
    {
        ContactContext CreateContext(string initialCatalog = null, bool proxyCreationEnabled = false);
    }
}
