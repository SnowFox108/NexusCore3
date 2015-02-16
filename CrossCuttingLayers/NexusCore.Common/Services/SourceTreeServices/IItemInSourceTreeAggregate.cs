using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Entities.SourceTrees;
using NexusCore.Common.Data.Enums;

namespace NexusCore.Common.Services.SourceTreeServices
{
    public interface IItemInSourceTreeAggregate
    {
        /// <summary>
        /// Suitable to get small list of child note itemIds
        /// </summary>
        /// <param name="itemId">Guid</param>
        /// <param name="itemType">SourceTreeItemType</param>
        /// <returns>IEnumerable ItemInSourceTree</returns>
        IEnumerable<ItemInSourceTree> GetItemsInSourceTree(Guid itemId, SourceTreeItemType itemType = SourceTreeItemType.None);

    }
}
