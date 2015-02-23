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

        public void DeleteItemInSourceTree(Guid itemInSourceTreeId)
        {
            UnitOfWork.Repository<ItemInSourceTree>().Delete(itemInSourceTreeId);
        }

        public Guid GetSourceTreeId(Guid itemId)
        {
            var item = UnitOfWork.Repository<ItemInSourceTree>().Get(i => i.ItemId == itemId).FirstOrDefault();
            if (item == null)
                return new Guid();                
            return item.SourceTreeId;
        }

        public ItemInSourceTree GetItemByItemId(Guid itemId)
        {
            return UnitOfWork.Repository<ItemInSourceTree>().Get(i => i.ItemId == itemId).FirstOrDefault();
        }

        public ItemInSourceTree GetItem(Guid sourceTreeId, SourceTreeItemModuleType itemModuleType = SourceTreeItemModuleType.System)
        {
            return UnitOfWork.Repository<ItemInSourceTree>().Get(i => i.SourceTreeId == sourceTreeId && i.ModuleType == itemModuleType).FirstOrDefault();
        }

        public ItemInSourceTree GetItem(SourceTree sourceTree, SourceTreeItemModuleType itemModuleType = SourceTreeItemModuleType.System)
        {
            return GetItem(sourceTree.Id, itemModuleType);
        }

        public IEnumerable<ItemInSourceTree> GetItems(IEnumerable<Guid> sourceTreeIds, SourceTreeItemModuleType itemModuleType = SourceTreeItemModuleType.System)
        {
            return UnitOfWork.Repository<ItemInSourceTree>().Get(i => sourceTreeIds.Contains(i.SourceTreeId) && i.ModuleType == itemModuleType);
        }

        public IEnumerable<ItemInSourceTree> GetItems(IEnumerable<SourceTree> sourceTrees, SourceTreeItemModuleType itemModuleType = SourceTreeItemModuleType.System)
        {
            return GetItems(sourceTrees.Select(s => s.Id).ToList(), itemModuleType);
        }
    }
}
