using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using NexusCore.Common.Adapter.IoC;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Infrastructure;
using NexusCore.Data.Infrastructure;

namespace NexusCore.WebAPI
{
    public class EngineConfig
    {
        public EngineConfig()
        {
            // Dependancy Injection initialize
            EngineContext.Instance.DiContainerInitialize(new AutofacFactory(
                builder =>
                {
                    builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
                    builder.RegisterType<ContentContext>().As<IContentContext>().InstancePerLifetimeScope();
                    builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
                },
                new AutofacRegisterWebApi(), 
                container =>
                {
                    var resolver = new AutofacWebApiDependencyResolver(container);
                    GlobalConfiguration.Configuration.DependencyResolver = resolver;
                }));
        }

    }
}