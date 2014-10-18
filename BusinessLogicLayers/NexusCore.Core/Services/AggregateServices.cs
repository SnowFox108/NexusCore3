using NexusCore.Common.Infrastructure;
using NexusCore.Common.Services;

namespace NexusCore.Core.Services
{
    public class AggregateServices : IAggregateServices
    {
        public IPrimitiveServices PrimitiveServices
        {
            get { return EngineContext.Instance.DiContainer.GetInstance<IPrimitiveServices>(); }
        }
    }
}
