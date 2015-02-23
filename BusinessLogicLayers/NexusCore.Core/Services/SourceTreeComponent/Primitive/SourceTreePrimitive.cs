using System;
using System.Collections.Generic;
using System.Linq;
using NexusCore.Common.Data.Entities.SourceTrees;
using NexusCore.Common.Data.Enums;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.SourceTrees;
using NexusCore.Common.Data.Specifications;
using NexusCore.Common.Services.SourceTreeServices;
using NexusCore.Core.Services.Infrastructure;

namespace NexusCore.Core.Services.SourceTreeComponent.Primitive
{
    public class SourceTreePrimitive : BasePrimitiveService, ISourceTreePrimitive
    {
        public SourceTreePrimitive(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void CreateSourceTree(SourceTree sourceTree)
        {
            UnitOfWork.Repository<SourceTree>().Insert(sourceTree);
        }

        public void DeleteSourceTree(Guid sourceTreeId)
        {
            UnitOfWork.Repository<SourceTree>().Delete(sourceTreeId);
        }

        public void DeleteSourceTree(SourceTree sourceTree)
        {
            UnitOfWork.Repository<SourceTree>().Delete(sourceTree);
        }

        public void UpdateSourceTree(SourceTree sourceTree)
        {
            UnitOfWork.Repository<SourceTree>().Update(sourceTree);
        }

        public SourceTree GetSourceTree(Guid sourceTreeId)
        {
            return UnitOfWork.Repository<SourceTree>().GetById(sourceTreeId);
        }

        /// <summary>
        /// Get Flat source list
        /// </summary>
        /// <param name="itemType">SourceTreeItemType</param>
        /// <returns>IEnumerable SourceTree</returns>
        public IEnumerable<SourceTree> GetSourceTreeNodes(SourceTreeItemType itemType = SourceTreeItemType.None)
        {
            return VerifyChildNodes(SourceTreeRoot.MasterNode, itemType);
        }

        /// <summary>
        /// Get Flat source list
        /// </summary>
        /// <param name="sourceTreeId">parent source tree Id</param>
        /// <param name="itemType">SourceTreeItemType</param>
        /// <returns>IEnumerable SourceTree</returns>
        public IEnumerable<SourceTree> GetSourceTreeNodes(Guid sourceTreeId, SourceTreeItemType itemType = SourceTreeItemType.None)
        {
            return VerifyChildNodes(GetSourceTree(sourceTreeId), itemType);
        }

        /// <summary>
        /// Get Flat source list
        /// </summary>
        /// <param name="parentNode">parent source tree node</param>
        /// <param name="itemType">SourceTreeItemType</param>
        /// <returns>IEnumerable SourceTree</returns>
        public IEnumerable<SourceTree> GetSourceTreeNodes(SourceTree parentNode, SourceTreeItemType itemType = SourceTreeItemType.None)
        {
            return VerifyChildNodes(parentNode, itemType);
        }

        private IEnumerable<SourceTree> VerifyChildNodes(SourceTree parentNode, SourceTreeItemType itemType)
        {
            var childNodes = GetChildNodes(parentNode.Id);
            foreach (var sourceTree in childNodes)
            {
                if (sourceTree.ItemType == itemType)
                    yield return sourceTree;
                foreach (var item in VerifyChildNodes(sourceTree, itemType))
                    yield return item;
            }
        }

        public SourceTree GetChildNode(Guid parentId, SourceTreeItemType itemType = SourceTreeItemType.None)
        {
            return GetChildNode(GetSourceTree(parentId), itemType);
        }

        public SourceTree GetChildNode(SourceTree parent,
            SourceTreeItemType itemType = SourceTreeItemType.None)
        {
            return parent.ChildNodes.AsQueryable().SingleOrDefault(SourceTreeSpecifications.ChildNodes(itemType).SatisfiedBy());
        }

        public IEnumerable<SourceTree> GetChildNodes(Guid parentId, SourceTreeItemType itemType = SourceTreeItemType.None)
        {
            return GetChildNodes(GetSourceTree(parentId), itemType);
        }

        public IEnumerable<SourceTree> GetChildNodes(SourceTree parent,
            SourceTreeItemType itemType = SourceTreeItemType.None)
        {
            return parent.ChildNodes.AsQueryable().Where(SourceTreeSpecifications.ChildNodes(itemType).SatisfiedBy());
        }

        public IEnumerable<SourceTree> GetChildNodes(Guid parentId, IEnumerable<SourceTreeItemType> itemTypes)
        {
            return GetChildNodes(GetSourceTree(parentId), itemTypes);
        }

        public IEnumerable<SourceTree> GetChildNodes(SourceTree parent, IEnumerable<SourceTreeItemType> itemTypes)
        {
            return parent.ChildNodes.AsQueryable().Where(SourceTreeSpecifications.ChildNodes(itemTypes).SatisfiedBy());
        }

        [Obsolete("retired method")]
        public SourceTree GetClientByCurrentNode(Guid sourceTreeId)
        {
            return GetClientByCurrentNode(GetSourceTree(sourceTreeId));
        }

        [Obsolete("retired method")]
        public SourceTree GetClientByCurrentNode(SourceTree sourceTree)
        {
            return GetParentSourceTree(sourceTree, SourceTreeItemType.Client);
        }

        [Obsolete("retired method")]
        private SourceTree GetParentSourceTree(SourceTree sourceTree, SourceTreeItemType itemType)
        {
            if (sourceTree.ItemType == itemType)
                return sourceTree;
            if (sourceTree.Parent == null)
                return sourceTree;
            return GetParentSourceTree(sourceTree.Parent, itemType);
        }

        public IEnumerable<SourceTree> GetClientNodes()
        {
            return GetChildNodes(SourceTreeRoot.MasterNode, SourceTreeItemType.Client);
        }

        public IEnumerable<SourceTree> GetWebsiteNodes(SourceTree websiteRoot)
        {
            return GetChildNodes(websiteRoot, SourceTreeItemType.Website);
        }

        public SourceTree GetWebsiteRoot(Guid clientId)
        {
            return GetChildNode(UnitOfWork.Repository<SourceTree>().GetById(clientId), SourceTreeItemType.WebsiteRoot);
        }

        public SourceTree GetWebsiteRoot(SourceTree client)
        {
            return GetChildNode(client, SourceTreeItemType.WebsiteRoot);
        }

        public SourceTree GetParentNode(Guid childId, SourceTreeItemType itemType = SourceTreeItemType.MasterRoot)
        {
            return VerifyParentNode(GetSourceTree(childId), itemType);
        }

        public SourceTree GetParentNode(SourceTree childNode, SourceTreeItemType itemType = SourceTreeItemType.MasterRoot)
        {
            return VerifyParentNode(childNode, itemType);
        }

        private SourceTree VerifyParentNode(SourceTree childNode, SourceTreeItemType itemType)
        {
            var parentNode = childNode.Parent;
            if (parentNode == null)
                return childNode;
            if (parentNode.ItemType == SourceTreeItemType.MasterRoot || parentNode.ItemType == itemType)
                return parentNode;
            return VerifyParentNode(parentNode, itemType);
        }

        public bool IsNodeExist(Guid id)
        {
            return UnitOfWork.Repository<SourceTree>().Get(s => s.Id == id).Any();
        }


    }
}
