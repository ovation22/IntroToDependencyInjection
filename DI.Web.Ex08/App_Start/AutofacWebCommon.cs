using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using DI.Web.Ex08.Repositories;
using DI.Web.Ex08.Services;

namespace DI.Web.Ex08
{
    public static class AutofacWebCommon
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Repository<string>>().As<IRepository<string>>();
            builder.RegisterType<SampleService>().As<ISampleService>();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var container = builder.Build();

            var resolver = new AutofacDependencyResolver(container);

            DependencyResolver.SetResolver(resolver);
        }
    }
}
