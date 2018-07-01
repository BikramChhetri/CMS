using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CMSApp.Models.DataAccessLayer.Factory
{
    public class ContextFactory : IContextFactory
    {
        public ContactContext CreateContext(string initialCatalog = null, bool proxyCreationEnabled = false)
        {
            var context = new ContactContext();
            context.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
            if (!string.IsNullOrWhiteSpace(initialCatalog))
            {
                context.SetInitialCatalog(initialCatalog);
            }
            return context;
        }
    }
    public static class ContextExtension
    {
        public static void SetInitialCatalog(this DbContext context, string initialCatalog)
        {
            var builder = new SqlConnectionStringBuilder(context.Database.Connection.ConnectionString)
            {
                InitialCatalog = initialCatalog
            };
            context.Database.Connection.ConnectionString = builder.ConnectionString;
        }
    }
}