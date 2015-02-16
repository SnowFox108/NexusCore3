using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexusCore.Common.Data.Entities.SourceTrees;
using NexusCore.Common.Data.Enums;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Services;
using NexusCore.Common.Services.SourceTreeServices;
using NexusCore.Core.Services.Infrastructure;

namespace NexusCore.Core.Services.SourceTreeComponent.Aggregate
{
    public class ItemInSourceTreeAggregate : BaseAggregateService, IItemInSourceTreeAggregate
    {
        public ItemInSourceTreeAggregate(IUnitOfWork unitOfWork, IPrimitiveServices primitiveServices) : base(unitOfWork, primitiveServices)
        {
        }

        public IEnumerable<ItemInSourceTree> GetItemsInSourceTree(Guid itemId, SourceTreeItemType itemType = SourceTreeItemType.None)
        {
            if (itemId == Guid.Empty)
                return new ItemInSourceTree[] { };

            var sourceTreeId = PrimitiveServices.ItemInSourceTreePrimitive.GetSourceTreeId(itemId);

            if (sourceTreeId == Guid.Empty)
                return new ItemInSourceTree[] { };

            var sourceTreeNodes = PrimitiveServices.SourceTreePrimitive.GetSourceTreeNodes(sourceTreeId, itemType).ToArray();

            if (!sourceTreeNodes.Any())
                return new ItemInSourceTree[] { };

            return PrimitiveServices.ItemInSourceTreePrimitive.GetItems(sourceTreeNodes.Select(s => s.Id)).ToArray();

        }
    }
}
