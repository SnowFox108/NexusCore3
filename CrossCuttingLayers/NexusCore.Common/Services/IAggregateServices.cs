
using NexusCore.Common.Services.ClientServices;
using NexusCore.Common.Services.SourceTreeServices;

namespace NexusCore.Common.Services
{
    public interface IAggregateServices
    {        
        IClientAggregate ClientAggregate { get; }
        ISourceTreeAggregate SourceTreeAggregate { get; }
    }
}
