using System;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework
{
    public class UnitOfWork<TContext> : UnitOfWorkBase<TContext> where TContext : class, IDisposable, IEFDataContext, new()
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
