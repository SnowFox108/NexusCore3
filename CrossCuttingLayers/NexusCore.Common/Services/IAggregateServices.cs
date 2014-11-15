
using NexusCore.Common.Services.ClientServices;
using NexusCore.Common.Services.PermissionServices;
using NexusCore.Common.Services.SourceTreeServices;

namespace NexusCore.Common.Services
{
    public interface IAggregateServices
    {        
        IClientAggregate ClientAggregate { get; }
        IPermissionAggregate PermissionAggregate { get; }
        ISourceTreeAggregate SourceTreeAggregate { get; }
    }
}
