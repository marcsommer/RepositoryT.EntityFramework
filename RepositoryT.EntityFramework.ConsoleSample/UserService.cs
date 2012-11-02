using System.Collections.Generic;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework.ConsoleSample
{
    //Basic service class :) For detailed implementation look at:
    //https://github.com/ziyasal/RepositoryT.RavenDb/tree/master/RepositoryT.RavenDb.Mvc4AutofacUOWSample/SampleBase
    public class UserService
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