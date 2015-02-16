using NexusCore.Common.Services.InstallationServices;
using NexusCore.Common.Services.MembershipServices;
using NexusCore.Common.Services.SourceTreeServices;
using NexusCore.Common.Services.WebsiteServices;

namespace NexusCore.Common.Services
{
    public interface IComponentServices
    {
        IInstallationService InstallationService { get; set; }
        IMembershipService MembershipService { get; set; }
        ISourceTreeService SourceTreeService { get; set; }
        IWebsiteService WebsiteService { get; set; }
    }
}
