using NexusCore.Infrasructure.Adapter.IoC;
using NexusCore.Infrasructure.Adapter.Logs;
using NexusCore.Infrasructure.Security;

namespace NexusCore.Infrasructure.Infrastructure
{
    public interface IEngine
    {
        IDiContainer DiContainer { get; }
        ICurrentUserProvider CurrentUser { get; }

        void Initialize(IDiContainerFactory diContainerFactory);
    }
}
