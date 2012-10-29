using System;
using System.Data.Entity;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework
{
    public class DefaultDataContextFactory<TContext> : IDataContextFactory<TContext> where TContext :DbContext, IDisposable, new()
    {
        private TContext _dataContext;

        #region IDatabaseFactory Members

        public TContext GetContext()
        {
            return _dataContext ?? (_dataContext = new TContext());
        }

        #endregion

        public void Dispose()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }
}