using NexusCore.Infrasructure.Adapter.IoC;

namespace NexusCore.Infrasructure.Infrastructure
{
    public interface IEngine
    {
        IDiContainer DiContainer { get; }
        void DiContainerInitialize(IDiContainerFactory diContainerFactory);
    }
}
