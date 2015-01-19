
using NexusCore.Common.Services.ClientServices;
using NexusCore.Common.Services.PermissionServices;
using NexusCore.Common.Services.SourceTreeServices;
using NexusCore.Common.Services.WebsiteServices;

namespace NexusCore.Common.Services
{
    public interface IAggregateServices
    {
        IClientAggregate ClientAggregate { get; set; }
        IPermissionAggregate PermissionAggregate { get; set; }
        ISourceTreeAggregate SourceTreeAggregate { get; set; }
        IWebsiteAggregate WebsiteAggregate { get; set; }
    }
}
