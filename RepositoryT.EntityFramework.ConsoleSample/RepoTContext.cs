using System.Data.Entity;

namespace RepositoryT.EntityFramework.ConsoleSample
{
    public class RepoTContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}