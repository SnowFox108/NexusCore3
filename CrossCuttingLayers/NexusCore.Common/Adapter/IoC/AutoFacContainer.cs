using Autofac;
using NexusCore.Infrasructure.Adapter.IoC;

namespace NexusCore.Common.Adapter.IoC
{
    public class AutofacContainer : IDiContainer
    {
        private readonly IContainer _container;

        public AutofacContainer(IContainer container)
        {
            _container = container;
        }

        public TService GetInstance<TService>() where TService : class
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                return scope.Resolve<TService>();
            }
        }
    }
}
