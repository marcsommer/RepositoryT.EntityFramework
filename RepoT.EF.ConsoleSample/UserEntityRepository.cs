namespace RepoT.EF.ConsoleSample
{
    public class UserEntityRepository : EntityRepository<User, RepoTContext>, IUserRepository
    {
        public UserEntityRepository(IDatabaseFactory<RepoTContext> databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}