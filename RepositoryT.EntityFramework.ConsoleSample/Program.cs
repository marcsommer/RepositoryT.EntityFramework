using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RepositoryT.EntityFramework.Extensions;
using RepositoryT.EntityFramework.SimpleBusiness;
using RepositoryT.EntityFramework.SimpleBusiness.Entities;
using RepositoryT.EntityFramework.SimpleBusiness.Repository;
using RepositoryT.EntityFramework.SimpleBusiness.Service;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework.ConsoleSample
{
    class Program
    {
        static void Main()
        {
            UserService userService = GetService();
            userService.AddUser(new User
                               {
                                   Email = "someone@somehost.com",
                                   FirstName = "Ziyasal",
                                   LastName = "Doe"
                               });
            userService.AddUser(new User
                                {
                                    Email = "someone@somehost.com",
                                    FirstName = "John",
                                    LastName = "Doe"
                                });

            foreach (User user in userService.GetAll())
            {
                Console.WriteLine("{0} {1}", user.FirstName, user.LastName);
            }

            TestDynamicMethods(userService);

            Console.Read();
        }

        private static void TestDynamicMethods(UserService userService)
        {
            Func<User, object> selector = product => (object)new { product.Id, product.Email };
            Expression<Func<User, object>> selectorExp = product => (object)new { product.Id, product.Email };
            Func<object, UserBrief> maker = product =>
            {
                UserBrief brief = new UserBrief();
                brief.Id = product.GetPropertyValue<int>(o => brief.Id);
                brief.Email = product.GetPropertyValue<string>(o => brief.Email);
                return brief;
            };

            TestWithFuncParam(userService, selector, maker);
            TestWithExpressionParam(userService, selectorExp, maker);
        }

        private static void TestWithFuncParam(UserService userService, Func<User, object> selector, Func<object, UserBrief> maker)
        {
            List<UserBrief> projectBriefs = userService.GetDynamic(selector, maker);

            foreach (var projectBrief in projectBriefs)
            {
                Console.WriteLine("Id: {0}, Title: {1}", projectBrief.Id, projectBrief.Email);
            }
        }

        private static void TestWithExpressionParam(UserService userService, Expression<Func<User, object>> selectorExp, Func<object, UserBrief> maker)
        {
            List<UserBrief> projectBriefsWithExp = userService.GetDynamic(selectorExp, maker);

            foreach (var projectBrief in projectBriefsWithExp)
            {
                Console.WriteLine("Id: {0}, Title: {1}", projectBrief.Id, projectBrief.Email);
            }
        }

        private static UserService GetService()
        {
            IDataContextFactory<SampleDataContext> dataContextFactory = new DataContextFactory();
            IUserRepository userRepository = new UserEntityRepository(dataContextFactory);
            IUnitOfWork uow = new UnitOfWork<SampleDataContext>(dataContextFactory);
            return new UserService(uow, userRepository);
        }
    }
}
