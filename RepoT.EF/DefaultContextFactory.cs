using System;
using RepoT.Infrastructure;

namespace RepoT.EF
{
    public class DefaultDataContextFactory<TContext> : CustomDisposable, IDataContextFactory<TContext> where TContext : class, IDisposable, new()
    {
        private TContext _dataContext;

        #region IDatabaseFactory Members

        public TContext GetContext()
        {
            return _dataContext ?? (_dataContext = new TContext());
        }

        #endregion

        protected override void DisposeCore()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }
}