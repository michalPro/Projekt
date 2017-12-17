using Autofac;
using Autofac.Integration.Mvc;
using SimpleProject.Contract.Repository;
using SimpleProject.Contract.Service;
using SimpleProject.DataAccess.Repository;
using SimpleProject.Service.Service;
using System.Web.Mvc;

namespace SimpleProject.App_Start
{
    public class AutofacConfig
    {
        public static void AutofacConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            // Repository
            builder.RegisterType<CarRepository>().As<ICarRepository>();

            // Services
            builder.RegisterType<CarService>().As<ICarService>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}