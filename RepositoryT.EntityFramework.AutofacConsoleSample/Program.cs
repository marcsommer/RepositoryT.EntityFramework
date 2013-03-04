using System;
using Autofac;
using RepositoryT.EntityFramework.SimpleBusiness;
using RepositoryT.EntityFramework.SimpleBusiness.Entities;
using RepositoryT.EntityFramework.SimpleBusiness.Repository;
using RepositoryT.EntityFramework.SimpleBusiness.Service;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework.AutofacConsoleSample
{
    class Program
    {
        private static IContainer IoC;

        static Program()
        {
            InitContainer();
        }

        private static void InitContainer()
        {
            var builder = new ContainerBuilder();

            builder.Register<IDataContextFactory<SampleDataContext>>(
                x => new DefaultDataContextFactory<SampleDataContext>()).InstancePerLifetimeScope();
            builder.Register<IUserRepository>(x => new UserEntityRepository(x.Resolve<IDataContextFactory<SampleDataContext>>())).SingleInstance();
            builder.Register<IUnitOfWork>(x => new UnitOfWork<SampleDataContext>(x.Resolve<IDataContextFactory<SampleDataContext>>())).SingleInstance();
            builder.Register<IUserService>(x => new UserService(x.Resolve<IUnitOfWork>(), x.Resolve<IUserRepository>())).SingleInstance();
            IoC = builder.Build();
        }

        static void Main()
        {

            IUserService userService = IoC.Resolve<IUserService>();
            User userToCreate1 = new User
                             {
                                 Email = "someone@somehost.com",
                                 FirstName = "Ziyasal",
                                 LastName = "Doe"
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
