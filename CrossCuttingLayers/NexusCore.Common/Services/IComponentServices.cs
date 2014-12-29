using NexusCore.Common.Services.InstallationServices;
using NexusCore.Common.Services.MembershipServices;

namespace NexusCore.Common.Services
{
    public interface IComponentServices
    {
        IInstallationService InstallationService { get; set; }
        IMembershipService MembershipService { get; set; }
    }
}
