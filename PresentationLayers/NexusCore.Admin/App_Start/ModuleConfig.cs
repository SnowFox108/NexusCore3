using System.Web.Mvc;
using Autofac.Integration.Mvc;
using NexusCore.Admin;
using NexusCore.Common.Adapter.IoC;
using NexusCore.Common.Infrastructure;
using NexusCore.Core.Adapter.IoC;
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
                builder => builder.RegisterControllers(typeof (MvcApplication).Assembly),
                new AutofacRegisterAdmin(),
                container => DependencyResolver.SetResolver(new AutofacDependencyResolver(container))));
        }
    }
}