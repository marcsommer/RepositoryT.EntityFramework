using RepoT.Infrastructure;

namespace RepoT.EF.ConsoleSample
{
    public class UserEntityRepository : EntityRepository<User, RepoTContext>, IUserRepository
    {
        public UserEntityRepository(IDataContextFactory<RepoTContext> databaseFactory)
            : base(databaseFactory)
        {
        }

        public bool Add(User entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}