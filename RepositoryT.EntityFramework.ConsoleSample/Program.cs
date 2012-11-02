using System;
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
                                   LastName = "XYZ"
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

            Console.Read();
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
