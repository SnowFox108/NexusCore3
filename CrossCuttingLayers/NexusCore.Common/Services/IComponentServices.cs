using NexusCore.Common.Services.Installation;

namespace NexusCore.Common.Services
{
    public interface IComponentServices
    {
        IAggregateServices AggregateServices { get; }

        IInstallationService InstallationService { get; }
    }
}
