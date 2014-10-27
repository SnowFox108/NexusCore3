
using NexusCore.Common.Services.ClientServices;

namespace NexusCore.Common.Services
{
    public interface IAggregateServices
    {        
        IClientAggregate ClientAggregate { get; }
    }
}
