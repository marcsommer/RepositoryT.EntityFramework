using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace RepoT.EF
{
    public interface IEFDataContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry Entry(object entity);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
    }
}