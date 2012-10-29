using System;
using System.Data.Entity;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework
{
    public class UnitOfWork<TContext> : UnitOfWorkBase<TContext> where TContext : DbContext, IDisposable, new()
    {

        public UnitOfWork(IDataContextFactory<TContext> databaseFactory)
            : base(databaseFactory)
        {

        }

        public override void Commit()
        {
            if (DataContext != null)
            {
                DataContext.SaveChanges();
            }
        }
    }
}
