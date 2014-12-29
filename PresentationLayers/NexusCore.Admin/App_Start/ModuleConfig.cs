using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using NexusCore.Admin;
using NexusCore.Admin.UILogic.Adapter.ErrorHandlers;
using NexusCore.Common.Adapter.IoC;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Infrastructure;
using NexusCore.Core.Adapter.IoC;
using NexusCore.Data.Infrastructure;
using NexusCore.Infrasructure.Adapter.ErrorHandlers;
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
            EngineContext.Instance.Initialize(new AutofacFactory(
                builder =>
                {
                    builder.RegisterControllers(typeof (MvcApplication).Assembly);
                    // Unit of Work
                    builder.RegisterType<ContentContext>().As<IContentContext>().InstancePerLifetimeScope();
                    builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
                    builder.RegisterType<WebErrorHandlerFactory>().As<IErrorHandlerFactory>().InstancePerLifetimeScope();

                },
                new AutofacRegisterAdmin(),
                container => DependencyResolver.SetResolver(new AutofacDependencyResolver(container))));
        }
    }
}