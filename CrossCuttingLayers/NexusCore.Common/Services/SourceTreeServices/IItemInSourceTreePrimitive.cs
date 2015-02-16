using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Entities.SourceTrees;
using NexusCore.Common.Data.Enums;

namespace NexusCore.Common.Services.SourceTreeServices
{
    public interface IItemInSourceTreePrimitive
    {        
        Guid GetSourceTreeId(Guid itemId);

        ItemInSourceTree GetItem(Guid sourceTreeId,
            SourceTreeItemModuleType itemModuleType = SourceTreeItemModuleType.System);

        IEnumerable<ItemInSourceTree> GetItems(IEnumerable<Guid> sourceTreeIds,
            SourceTreeItemModuleType itemModuleType = SourceTreeItemModuleType.System);
    }
}
