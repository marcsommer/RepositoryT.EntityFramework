using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public List<UserBrief> GetDynamic(Func<User, object> selector, Func<object, UserBrief> maker)
        {
            return _userRepository.GetDynamic(selector, maker);
        }

        public List<UserBrief> GetDynamic(Expression<Func<User, object>> selector, Func<object, UserBrief> maker)
        {
            return _userRepository.GetDynamic(selector, maker);
        }
    }
}