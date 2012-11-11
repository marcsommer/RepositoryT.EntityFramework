using System.Collections.Generic;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework.AutofacConsoleSample
{
    //Basic service class :) For detailed implementation look at:
    //https://github.com/ziyasal/RepositoryT.RavenDb/tree/master/RepositoryT.RavenDb.Mvc4AutofacUOWSample/SampleBase
    public interface IUserService
    {
        int AddUser(User user);
        IEnumerable<User> GetAll();
    }

    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public int AddUser(User user)
        {
            _userRepository.Add(user);
            _unitOfWork.Commit();
            return user.Id;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
}