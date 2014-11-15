using NexusCore.Common.Infrastructure;
using NexusCore.Common.Services;
using NexusCore.Common.Services.ClientServices;
using NexusCore.Common.Services.FriendlyIdServices;
using NexusCore.Common.Services.PermissionServices;
using NexusCore.Common.Services.SourceTreeServices;
using NexusCore.Common.Services.WebsiteServices;

namespace NexusCore.Core.Services.Infrastructure
{
    public class PrimitiveServices : IPrimitiveServices
    {
        public IClientPrimitive ClientPrimitive
        {
            get { return EngineContext.Instance.DiContainer.GetInstance<IClientPrimitive>(); }
        }

        public IDomainPrimitive DomainPrimitive
        {
            get { return EngineContext.Instance.DiContainer.GetInstance<IDomainPrimitive>(); }
        }

        public IFriendlyIdPrimitive FriendlyIdPrimitive
        {
            get { return EngineContext.Instance.DiContainer.GetInstance<IFriendlyIdPrimitive>(); }
        }

        public IItemInSourceTreePrimitive ItemInSourceTreePrimitive
        {
            get { return EngineContext.Instance.DiContainer.GetInstance<IItemInSourceTreePrimitive>(); }
        }

        public IPermissionPrimitive PermissionPrimitive
        {
            get { return EngineContext.Instance.DiContainer.GetInstance<IPermissionPrimitive>(); }
        }

        public ISourceTreePrimitive SourceTreePrimitive
        {
            get { return EngineContext.Instance.DiContainer.GetInstance<ISourceTreePrimitive>(); }
        }

        public IWebsitePrimitive WebsitePrimitive
        {
            get { return EngineContext.Instance.DiContainer.GetInstance<IWebsitePrimitive>(); }
        }

    }
}
