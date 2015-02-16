using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Entities.SourceTrees;
using NexusCore.Common.Data.Enums;

namespace NexusCore.Common.Services.SourceTreeServices
{
    public interface ISourceTreePrimitive
    {
        SourceTree GetSourceTree(Guid sourceTreeId);

        /// <summary>
        /// Get Flat source list
        /// </summary>
        /// <param name="itemType">SourceTreeItemType</param>
        /// <returns>IEnumerable SourceTree</returns>
        IEnumerable<SourceTree> GetSourceTreeNodes(SourceTreeItemType itemType = SourceTreeItemType.None);

        /// <summary>
        /// Get Flat source list
        /// </summary>
        /// <param name="sourceTreeId">parent source tree Id</param>
        /// <param name="itemType">SourceTreeItemType</param>
        /// <returns>IEnumerable SourceTree</returns>
        IEnumerable<SourceTree> GetSourceTreeNodes(Guid sourceTreeId,
            SourceTreeItemType itemType = SourceTreeItemType.None);

        /// <summary>
        /// Get Flat source list
        /// </summary>
        /// <param name="parentNode">parent source tree node</param>
        /// <param name="itemType">SourceTreeItemType</param>
        /// <returns>IEnumerable SourceTree</returns>
        IEnumerable<SourceTree> GetSourceTreeNodes(SourceTree parentNode,
            SourceTreeItemType itemType = SourceTreeItemType.None);


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

        /// <summary>
        /// Get nearest parent that match item type 
        /// </summary>
        /// <param name="childId">Guid</param>
        /// <param name="itemType">SourceTreeItemType</param>
        /// <returns>SourceTree</returns>
        SourceTree GetParentNode(Guid childId, SourceTreeItemType itemType = SourceTreeItemType.MasterRoot);

        /// <summary>
        /// Get nearest parent that match item type 
        /// </summary>
        /// <param name="child">SourceTree</param>
        /// <param name="itemType">SourceTreeItemType</param>
        /// <returns>SourceTree</returns>
        SourceTree GetParentNode(SourceTree child, SourceTreeItemType itemType = SourceTreeItemType.MasterRoot);

        bool IsNodeExist(Guid id);

    }
}
