using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Entities.SourceTree;
using NexusCore.Common.Data.Models.SourceTree;

namespace NexusCore.Common.Services.Primitive
{
    public interface ISourceTreePrimitive
    {
        IEnumerable<SourceTree> GetChildNodes(Guid parentId,
            SourceTreeItemType itemType = SourceTreeItemType.None);

        IEnumerable<SourceTree> GetChildNodes(Guid parentId, IEnumerable<SourceTreeItemType> itemTypes);
    }
}
