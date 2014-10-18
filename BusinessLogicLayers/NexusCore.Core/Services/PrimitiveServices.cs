using NexusCore.Common.Infrastructure;
using NexusCore.Common.Services;
using NexusCore.Common.Services.SourceTree;

namespace NexusCore.Core.Services
{
    public class PrimitiveServices : IPrimitiveServices
    {
        public ISourceTreePrimitive SourceTreePrimitive
        {
            get { return EngineContext.Instance.DiContainer.GetInstance<ISourceTreePrimitive>(); }
        }
    }
}
