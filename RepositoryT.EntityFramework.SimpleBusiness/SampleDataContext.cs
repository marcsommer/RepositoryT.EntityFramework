using System.Data.Entity;
using RepositoryT.EntityFramework.SimpleBusiness.Entities;

namespace RepositoryT.EntityFramework.SimpleBusiness
{
    public class SampleDataContext : DbContext, IDbContext
    {
        public DbSet<User> Users { get; set; }
    }
}