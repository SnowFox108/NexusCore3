using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using NexusCore.Common.Adapter.IoC;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Infrastructure;
using NexusCore.Core.Adapter.IoC;
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
                    // Unit of Work
                    builder.RegisterType<ContentContext>().As<IContentContext>().InstancePerRequest();
                    builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();                    
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