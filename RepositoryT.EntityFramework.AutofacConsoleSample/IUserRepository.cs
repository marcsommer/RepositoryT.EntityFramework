using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework.AutofacConsoleSample
{
    public interface IUserRepository : IRepository<User>
    {
    }
}