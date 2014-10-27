using NexusCore.Common.Infrastructure;
using NexusCore.Common.Services;
using NexusCore.Common.Services.InstallationServices;

namespace NexusCore.Core.Services.Infrastructure
{
    public class ComponentServices : IComponentServices
    {
        public IAggregateServices AggregateServices
        {
            get { return EngineContext.Instance.DiContainer.GetInstance<IAggregateServices>(); }
        }

        public IInstallationService InstallationService
        {
            get { return EngineContext.Instance.DiContainer.GetInstance<IInstallationService>(); }
        }
    }
}
