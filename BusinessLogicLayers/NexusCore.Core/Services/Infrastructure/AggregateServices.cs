using NexusCore.Common.Services;
using NexusCore.Common.Services.ClientServices;
using NexusCore.Common.Services.PermissionServices;
using NexusCore.Common.Services.SourceTreeServices;
using NexusCore.Common.Services.WebsiteServices;

namespace NexusCore.Core.Services.Infrastructure
{
    public class AggregateServices : IAggregateServices
    {
        public IClientAggregate ClientAggregate { get; set; }
        public IPermissionAggregate PermissionAggregate { get; set; }
        public ISourceTreeAggregate SourceTreeAggregate { get; set; }
        public IWebsiteAggregate WebsiteAggregate { get; set; }
    }
}
