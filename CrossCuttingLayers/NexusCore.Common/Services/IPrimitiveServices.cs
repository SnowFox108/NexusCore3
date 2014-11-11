using NexusCore.Common.Services.ClientServices;
using NexusCore.Common.Services.FriendlyIdServices;
using NexusCore.Common.Services.SourceTreeServices;
using NexusCore.Common.Services.WebsiteServices;

namespace NexusCore.Common.Services
{
    public interface IPrimitiveServices
    {
        IClientPrimitive ClientPrimitive { get; }
        IDomainPrimitive DomainPrimitive { get; }
        IFriendlyIdPrimitive FriendlyIdPrimitive { get; }
        IItemInSourceTreePrimitive ItemInSourceTreePrimitive { get; }
        ISourceTreePrimitive SourceTreePrimitive { get; }
        IWebsitePrimitive WebsitePrimitive { get; }
    }
}
