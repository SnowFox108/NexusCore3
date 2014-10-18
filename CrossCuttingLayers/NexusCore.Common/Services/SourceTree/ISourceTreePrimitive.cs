using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Models.SourceTree;

namespace NexusCore.Common.Services.SourceTree
{
    public interface ISourceTreePrimitive
    {
        IEnumerable<Data.Entities.SourceTree.SourceTree> GetChildNodes(Guid parentId,
            SourceTreeItemType itemType = SourceTreeItemType.None);

        IEnumerable<Data.Entities.SourceTree.SourceTree> GetChildNodes(Guid parentId, IEnumerable<SourceTreeItemType> itemTypes);
    }
}
