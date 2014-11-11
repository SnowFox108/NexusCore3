using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Entities.SourceTrees;
using NexusCore.Common.Data.Models.SourceTrees;

namespace NexusCore.Common.Services.SourceTreeServices
{
    public interface ISourceTreePrimitive
    {
        SourceTree GetChildNode(Guid parentId,
            SourceTreeItemType itemType = SourceTreeItemType.None);

        IEnumerable<SourceTree> GetChildNodes(Guid parentId,
            SourceTreeItemType itemType = SourceTreeItemType.None);

        IEnumerable<SourceTree> GetChildNodes(Guid parentId, IEnumerable<SourceTreeItemType> itemTypes);

        IEnumerable<SourceTree> GetClientNodes();

        IEnumerable<SourceTree> GetWebsiteNodes(Guid websiteRootId);
        SourceTree GetWebsiteRoot(Guid clientRootId);

        bool IsNodeExist(Guid id);

    }
}
