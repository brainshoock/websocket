using System.Data.Entity;

namespace TestApplication.Server.Entities
{
    public class DefaultDbContext : DbContext
    {
        public DbSet<PriceItemEntity> PriceItems { get; set; }

        public DefaultDbContext() : base("DefaultDbConnection")
		{
            
        }
    }
}
