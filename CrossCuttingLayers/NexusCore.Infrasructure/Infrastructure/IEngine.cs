using NexusCore.Infrasructure.Adapter.IoC;
using NexusCore.Infrasructure.Adapter.Logging;
using NexusCore.Infrasructure.Adapter.Logs;

namespace NexusCore.Infrasructure.Infrastructure
{
    public interface IEngine
    {
        IDiContainer DiContainer { get; }
        void DiContainerInitialize(IDiContainerFactory diContainerFactory);
        ILogger Logger { get; }
    }
}
