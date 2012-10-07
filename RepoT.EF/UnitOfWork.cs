using System;

namespace RepoT.EF
{
    public class UnitOfWork<TContext> : UnitOfWorkBase<TContext> where TContext : class, IDisposable, IEFDataContext, new()
    {

        public UnitOfWork(IDatabaseFactory<TContext> databaseFactory)
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
