using NexusCore.Common.Data.Infrastructure;

namespace NexusCore.Core.Services.Infrastructure
{
    public class BasePrimitiveService
    {
        protected readonly IUnitOfWork UnitOfWork;

        public BasePrimitiveService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
