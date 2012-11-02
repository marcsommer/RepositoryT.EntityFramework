using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework.ConsoleSample
{
    public class UserEntityRepository : EntityRepository<User, SampleDataContext>, IUserRepository
    {
        public UserEntityRepository(IDataContextFactory<SampleDataContext> databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}