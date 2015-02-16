using System;
using System.Collections.Generic;
using System.Linq;
using NexusCore.Common.Data.Entities.SourceTrees;
using NexusCore.Common.Data.Enums;
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

        public ItemInSourceTree GetItem(Guid sourceTreeId, SourceTreeItemModuleType itemModuleType = SourceTreeItemModuleType.System)
        {
            return UnitOfWork.Repository<ItemInSourceTree>().Get(i => i.SourceTreeId == sourceTreeId && i.ModuleType == itemModuleType).FirstOrDefault();
        }

        public IEnumerable<ItemInSourceTree> GetItems(IEnumerable<Guid> sourceTreeIds, SourceTreeItemModuleType itemModuleType = SourceTreeItemModuleType.System)
        {
            return UnitOfWork.Repository<ItemInSourceTree>().Get(i => sourceTreeIds.Contains(i.SourceTreeId) && i.ModuleType == itemModuleType);
        }



    }
}
