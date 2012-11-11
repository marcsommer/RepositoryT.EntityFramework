using System;
using Autofac;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework.AutofacConsoleSample
{
    class Program
    {
        private static IContainer _container;

        static Program()
        {
            InitContainer();
        }

        private static void InitContainer()
        {
            var builder = new ContainerBuilder();

            builder.Register<IDataContextFactory<SampleDataContext>>(x => new DataContextFactory()).SingleInstance();
            builder.Register<IUserRepository>(x => new UserEntityRepository(x.Resolve<IDataContextFactory<SampleDataContext>>())).SingleInstance();
            builder.Register<IUnitOfWork>(x => new UnitOfWork<SampleDataContext>(x.Resolve<IDataContextFactory<SampleDataContext>>())).SingleInstance();
            builder.Register<IUserService>(x => new UserService(x.Resolve<IUnitOfWork>(), x.Resolve<IUserRepository>())).SingleInstance();
            _container = builder.Build();
        }

        static void Main()
        {

            IUserService userService = _container.Resolve<IUserService>();
            User userToCreate1 = new User
                             {
                                 Email = "someone@somehost.com",
                                 FirstName = "Ziyasal",
                                 LastName = "XYZ"
                             };
            userService.AddUser(userToCreate1);
            User userToCreate2 = new User
                             {
                                 Email = "someone@somehost.com",
                                 FirstName = "John",
                                 LastName = "Doe"
                             };
            userService.AddUser(userToCreate2);

            foreach (User user in userService.GetAll())
            {
                Console.WriteLine("{0} {1}", user.FirstName, user.LastName);
            }

            Console.Read();
        }
    }
}
