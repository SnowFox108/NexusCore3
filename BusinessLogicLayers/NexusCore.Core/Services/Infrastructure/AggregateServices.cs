using NexusCore.Common.Infrastructure;
using NexusCore.Common.Services;
using NexusCore.Common.Services.ClientServices;
using NexusCore.Common.Services.PermissionServices;
using NexusCore.Common.Services.SourceTreeServices;

namespace NexusCore.Core.Services.Infrastructure
{
    public class AggregateServices : IAggregateServices
    {
        public IClientAggregate ClientAggregate
        {
            get { return GetInstance<IClientAggregate>(); }
        }

        public IPermissionAggregate PermissionAggregate
        {
            get { return GetInstance<IPermissionAggregate>(); }
        }

        public ISourceTreeAggregate SourceTreeAggregate
        {
            get { return GetInstance<ISourceTreeAggregate>(); }
        }

        private T GetInstance<T>() where T : class
        {
            return EngineContext.Instance.DiContainer.GetInstance<T>();
        }




    }
}
