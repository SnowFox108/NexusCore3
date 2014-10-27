using NexusCore.Common.Infrastructure;
using NexusCore.Common.Services;
using NexusCore.Common.Services.FriendlyIdServices;
using NexusCore.Common.Services.SourceTreeServices;

namespace NexusCore.Core.Services.Infrastructure
{
    public class PrimitiveServices : IPrimitiveServices
    {
        public IFriendlyIdPrimitive FriendlyIdPrimitive
        {
            get { return EngineContext.Instance.DiContainer.GetInstance<IFriendlyIdPrimitive>(); }
        }

        public ISourceTreePrimitive SourceTreePrimitive
        {
            get { return EngineContext.Instance.DiContainer.GetInstance<ISourceTreePrimitive>(); }
        }

    }
}
