using System.Reflection;
using System.Web.Http;
using Autofac.Integration.WebApi;
using NexusCore.Common.Adapter.IoC;
using NexusCore.Common.Infrastructure;
using NexusCore.Core.Adapter.IoC;

namespace NexusCore.WebAPI
{
    public class EngineConfig
    {
        public EngineConfig()
        {
            // Dependancy Injection initialize
            EngineContext.Instance.DiContainerInitialize(new AutofacFactory(
                builder => builder.RegisterApiControllers(Assembly.GetExecutingAssembly()),
                new AutofacRegisterWebApi(), 
                container =>
                {
                    var resolver = new AutofacWebApiDependencyResolver(container);
                    GlobalConfiguration.Configuration.DependencyResolver = resolver;
                }));
        }
    }
}