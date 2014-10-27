using NexusCore.Common.Services.FriendlyIdServices;
using NexusCore.Common.Services.SourceTreeServices;

namespace NexusCore.Common.Services
{
    public interface IPrimitiveServices
    {
        IFriendlyIdPrimitive FriendlyIdPrimitive { get; }
        ISourceTreePrimitive SourceTreePrimitive { get; }
    }
}
