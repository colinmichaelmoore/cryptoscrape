using System.Data.Entity;

namespace crypto
{
    public class CurrencyContext : DbContext
    {
        public CurrencyContext(): base()
        {
            
        }

        public DbSet<Currency> Currencies { get; set; }
    }
}