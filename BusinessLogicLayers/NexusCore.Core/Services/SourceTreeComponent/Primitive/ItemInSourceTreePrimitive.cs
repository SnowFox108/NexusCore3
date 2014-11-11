using System;
using System.Linq;
using NexusCore.Common.Data.Entities.SourceTrees;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Services.SourceTreeServices;
using NexusCore.Core.Services.Infrastructure;

namespace NexusCore.Core.Services.SourceTreeComponent.Primitive
{
    public class ItemInSourceTreePrimitive : BasePrimitiveService, IItemInSourceTreePrimitive
    {
        public ItemInSourceTreePrimitive(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Guid GetSourceTreeId(Guid itemId)
        {
            var item = UnitOfWork.Repository<ItemInSourceTree>().Get(i => i.ItemId == itemId).FirstOrDefault();
            if (item == null)
                return new Guid();
            return item.SourceTreeId;
        }
    }
}
