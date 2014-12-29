
using NexusCore.Common.Services.ClientServices;
using NexusCore.Common.Services.PermissionServices;
using NexusCore.Common.Services.SourceTreeServices;

namespace NexusCore.Common.Services
{
    public interface IAggregateServices
    {
        IClientAggregate ClientAggregate { get; set; }
        IPermissionAggregate PermissionAggregate { get; set; }
        ISourceTreeAggregate SourceTreeAggregate { get; set; }
    }
}
