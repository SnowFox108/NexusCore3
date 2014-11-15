using NexusCore.Common.Data.Infrastructure;

namespace NexusCore.Data.Infrastructure
{
    public class UnitOfWorkAsyncFactory : IUnitOfWorkAsyncFactory
    {
        public IUnitOfWork Create()
        {
            return new UnitOfWork(new ContentContext());
        }
    }
}
