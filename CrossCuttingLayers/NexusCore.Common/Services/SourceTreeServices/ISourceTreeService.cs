using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Entities.SourceTrees;
using NexusCore.Common.Data.Enums;
using NexusCore.Common.Data.Models.SourceTrees;

namespace NexusCore.Common.Services.SourceTreeServices
{
    public interface ISourceTreeService
    {
        IEnumerable<Guid> GetItemIds(SourceTreeItemType itemType);
        IEnumerable<Guid> GetClientNodeIds();
        IEnumerable<SourceTree> GetClientNodes();
        IEnumerable<Guid> GetWebsiteIds();
        IEnumerable<SourceTree> GetWebsiteNodes();
        SourceTreeModel GetSourceTreeBuild();
        IEnumerable<SourceTree> GetSourceTreeNodes(SourceTreeItemType itemType);
    }
}
