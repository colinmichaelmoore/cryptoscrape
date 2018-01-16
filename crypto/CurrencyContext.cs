using System.Data.Entity;

namespace Scrape
{
    public class CurrencyContext : DbContext
    {
        public CurrencyContext(): base()
        {
            
        }

        public DbSet<Currency> Currencies { get; set; }
    }
}