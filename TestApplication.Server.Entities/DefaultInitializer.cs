using System.Data.Entity;

namespace TestApplication.Server.Entities
{
    public class DefaultInitializer : DropCreateDatabaseIfModelChanges<DefaultDbContext>
    {

    }
}
