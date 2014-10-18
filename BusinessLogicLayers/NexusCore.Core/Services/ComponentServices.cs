using NexusCore.Common.Infrastructure;
using NexusCore.Common.Services;
using NexusCore.Common.Services.Installation;

namespace NexusCore.Core.Services
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
