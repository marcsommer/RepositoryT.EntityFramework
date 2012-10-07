using System.Data.Entity;

namespace RepoT.EF.ConsoleSample
{
    public class RepoTContext : DbContext, IEFDataContext
    {
        public DbSet<User> Users { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}