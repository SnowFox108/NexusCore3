using NexusCore.Common.Infrastructure;
using NexusCore.Common.Services;
using NexusCore.Common.Services.ClientServices;

namespace NexusCore.Core.Services.Infrastructure
{
    public class AggregateServices : IAggregateServices
    {
        public IClientAggregate ClientAggregate
        {
            get { return GetInstance<IClientAggregate>(); }
        }

        private T GetInstance<T>() where T : class
        {
            return EngineContext.Instance.DiContainer.GetInstance<T>();
        }
    }
}
