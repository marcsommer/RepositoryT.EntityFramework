using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework.ConsoleSample
{
    public class DataContextFactory : IDataContextFactory<SampleDataContext>
    {
        private SampleDataContext _dataContext;

        public SampleDataContext GetContext()
        {
            return _dataContext ?? (_dataContext = new SampleDataContext());
        }

        public void Dispose()
        {
            if (_dataContext != null)
            {
                _dataContext.Dispose();
            }
        }
    }
}