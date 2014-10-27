using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Models.SourceTree;

namespace NexusCore.Common.Services.SourceTreeServices
{
    public interface ISourceTreePrimitive
    {
        void CreateClientNode(Guid clientId, string clientName);

        IEnumerable<Data.Entities.SourceTree.SourceTree> GetChildNodes(Guid parentId,
            SourceTreeItemType itemType = SourceTreeItemType.None);

        IEnumerable<Data.Entities.SourceTree.SourceTree> GetChildNodes(Guid parentId, IEnumerable<SourceTreeItemType> itemTypes);

        bool IsNodeExist(Guid id);

    }
}
