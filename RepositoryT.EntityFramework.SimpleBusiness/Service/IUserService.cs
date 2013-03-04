using System.Collections.Generic;
using RepositoryT.EntityFramework.SimpleBusiness.Entities;

namespace RepositoryT.EntityFramework.SimpleBusiness.Service
{
    public interface IUserService
    {
        int AddUser(User user);
        IEnumerable<User> GetAll();
    }
}