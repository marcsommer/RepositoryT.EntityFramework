using System.Data.Entity;

namespace RepositoryT.EntityFramework.AutofacConsoleSample
{
    public class SampleDataContext : DbContext, IDbContext
    {
        public DbSet<User> Users { get; set; }
    }
}