using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Infrastructure;
using NexusCore.Infrasructure.Security;

namespace NexusCore.Data.Infrastructure
{
    public class UnitOfWorkAsyncFactory : IUnitOfWorkAsyncFactory
    {
        public IUnitOfWork Create()
        {
            return new UnitOfWork(new ContentContext(),
                EngineContext.Instance.DiContainer.GetInstance<ICurrentUserProvider>());
        }
    }
}
