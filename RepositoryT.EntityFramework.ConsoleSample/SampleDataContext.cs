using System.Data.Entity;

namespace RepositoryT.EntityFramework.ConsoleSample
{
    public class SampleDataContext : DbContext, IDbContext
    {
        public DbSet<User> Users { get; set; }
    }
}