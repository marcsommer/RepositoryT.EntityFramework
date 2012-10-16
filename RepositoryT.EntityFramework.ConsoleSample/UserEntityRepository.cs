using System;
using System.Linq.Expressions;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework.ConsoleSample
{
    public class UserEntityRepository : EntityRepository<User, RepoTContext>, IUserRepository
    {
        public UserEntityRepository(IDataContextFactory<RepoTContext> databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}