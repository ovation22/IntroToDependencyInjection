using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using DI.Web.Ex09.Repositories;
using DI.Web.Ex09.Attributes;
using DI.Web.Ex09.Extensions;

namespace DI.Web.Ex09
{
    public static class AutofacWebCommon
    {
        private static ContainerBuilder _builder;

        public static void RegisterDependencies()
        {
            _builder = new ContainerBuilder();

            _builder.RegisterControllers(typeof(MvcApplication).Assembly);

            RegisterItems();

            var container = _builder.Build();

            var resolver = new AutofacDependencyResolver(container);

            DependencyResolver.SetResolver(resolver);
        }

        private static void RegisterItems()
        {
            _builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));

            RegisterServices();
        }

        private static void RegisterServices()
        {
            var serviceList = AppDomain.CurrentDomain.GetAssemblies()
                .Where(aa => aa.FullName.IndexOf("DI.Web.Ex09", StringComparison.Ordinal) > -1)
                .SelectMany(a =>
                    a.GetTypes()
                    .Where(t => t.HasAttribute(typeof(InjectAttribute)) && t.IsPublic)
                );

            foreach (var t in serviceList)
            {
                var attribs = t.GetCustomAttributes<InjectAttribute>();
                foreach (var attrib in attribs)
                {
                    _builder.RegisterType(t)
                        .As(attrib.BindingType).InstancePerRequest();
                }
            }
        }
    }
}

