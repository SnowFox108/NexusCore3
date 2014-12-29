using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Entities.SourceTrees;
using NexusCore.Common.Data.Enums;
using NexusCore.Common.Data.Models.SourceTrees;

namespace NexusCore.Common.Services.SourceTreeServices
{
    public interface ISourceTreePrimitive
    {
        SourceTree GetSourceTree(Guid sourceTreeId);

        SourceTree GetChildNode(Guid parentId, SourceTreeItemType itemType = SourceTreeItemType.None);

        SourceTree GetChildNode(SourceTree parent,
            SourceTreeItemType itemType = SourceTreeItemType.None);

        IEnumerable<SourceTree> GetChildNodes(Guid parentId, SourceTreeItemType itemType = SourceTreeItemType.None);

        IEnumerable<SourceTree> GetChildNodes(SourceTree parent,
            SourceTreeItemType itemType = SourceTreeItemType.None);

        IEnumerable<SourceTree> GetChildNodes(Guid parentId, IEnumerable<SourceTreeItemType> itemTypes);

        IEnumerable<SourceTree> GetChildNodes(SourceTree parent, IEnumerable<SourceTreeItemType> itemTypes);

        IEnumerable<SourceTree> GetClientNodes();

        SourceTree GetClientByCurrentNode(Guid sourceTreeId);

        SourceTree GetClientByCurrentNode(SourceTree sourceTree);

        IEnumerable<SourceTree> GetWebsiteNodes(SourceTree websiteRoot);

        SourceTree GetWebsiteRoot(Guid clientId);
        SourceTree GetWebsiteRoot(SourceTree client);

        bool IsNodeExist(Guid id);

    }
}
