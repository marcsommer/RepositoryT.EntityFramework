using RepositoryT.EntityFramework.SimpleBusiness.Entities;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework.SimpleBusiness.Repository
{
    public class UserEntityRepository : EntityRepository<User, SampleDataContext>, IUserRepository
    {
        public UserEntityRepository(IDataContextFactory<SampleDataContext> databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}