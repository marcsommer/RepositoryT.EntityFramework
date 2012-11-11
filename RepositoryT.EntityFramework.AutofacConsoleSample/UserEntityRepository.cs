using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework.AutofacConsoleSample
{
    public class UserEntityRepository : EntityRepository<User, SampleDataContext>, IUserRepository
    {
        public UserEntityRepository(IDataContextFactory<SampleDataContext> databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}