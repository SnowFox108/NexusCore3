using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Services;

namespace NexusCore.Core.Services.Infrastructure
{
    public class BaseAggregateService
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IPrimitiveServices PrimitiveServices;

        public BaseAggregateService(IUnitOfWork unitOfWork, IPrimitiveServices primitiveServices)
        {
            UnitOfWork = unitOfWork;
            PrimitiveServices = primitiveServices;
        }
    }
}
