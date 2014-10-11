using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using NexusCore.Admin;
using NexusCore.Common.Adapter.IoC;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Infrastructure;
using NexusCore.Data.Infrastructure;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(ModuleConfig), "Start")]
[assembly: ApplicationShutdownMethod(typeof(ModuleConfig), "Stop")]

namespace NexusCore.Admin
{
    public class ModuleConfig
    {
        public static void Start()
        {
            EngineConfig();
        }

        public static void Stop()
        {

        }

        private static void EngineConfig()
        {
            // Dependancy Injection initialize
            EngineContext.Instance.DiContainerInitialize(new AutofacFactory(
                builder =>
                {
                    builder.RegisterControllers(typeof(MvcApplication).Assembly);
                    builder.RegisterType<ContentContext>().As<IContentContext>().InstancePerLifetimeScope();
                    builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
                },
                new AutofacRegisterAdmin(),
                container => DependencyResolver.SetResolver(new AutofacDependencyResolver(container))));            
        }

    }
}