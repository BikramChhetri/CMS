namespace CMSApp.Models.DataAccessLayer.Factory
{
    public interface IContextFactory
    {
        ContactContext CreateContext(string initialCatalog = null, bool proxyCreationEnabled = false);
    }
}
