using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Services;

namespace NexusCore.Core.Services.Infrastructure
{
    public class BaseComponentService
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IPrimitiveServices PrimitiveServices;
        protected readonly IAggregateServices AggregateServices;

        public BaseComponentService(IUnitOfWork unitOfWork,IPrimitiveServices primitiveServices, IAggregateServices aggregateServices)
        {
            UnitOfWork = unitOfWork;
            PrimitiveServices = primitiveServices;
            AggregateServices = aggregateServices;
        }
    }
}
