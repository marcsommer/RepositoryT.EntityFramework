using System;
using RepoT.Infrastructure;

namespace RepoT.EF
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
