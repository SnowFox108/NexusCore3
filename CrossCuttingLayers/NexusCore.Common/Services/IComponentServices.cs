using NexusCore.Common.Services.InstallationServices;

namespace NexusCore.Common.Services
{
    public interface IComponentServices
    {
        IInstallationService InstallationService { get; }
    }
}
