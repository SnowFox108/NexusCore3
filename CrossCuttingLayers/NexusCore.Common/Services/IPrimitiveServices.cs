using NexusCore.Common.Services.FriendlyId;
using NexusCore.Common.Services.SourceTree;
using NexusCore.Infrasructure.Adapter.IdGenerator;

namespace NexusCore.Common.Services
{
    public interface IPrimitiveServices
    {
        IFriendlyIdPrimitive FriendlyIdPrimitive { get; }
        ISourceTreePrimitive SourceTreePrimitive { get; }
    }
}
