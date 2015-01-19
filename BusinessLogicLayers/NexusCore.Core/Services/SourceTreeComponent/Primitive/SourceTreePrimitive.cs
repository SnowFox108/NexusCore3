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

        public SourceTree GetSourceTree(Guid sourceTreeId)
        {
            return UnitOfWork.Repository<SourceTree>().GetById(sourceTreeId);
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

        public SourceTree GetClientByCurrentNode(Guid sourceTreeId)
        {
            return GetClientByCurrentNode(GetSourceTree(sourceTreeId));
        }

        public SourceTree GetClientByCurrentNode(SourceTree sourceTree)
        {
            return GetParentSourceTree(sourceTree, SourceTreeItemType.Client);
        }

        private SourceTree GetParentSourceTree(SourceTree sourceTree, SourceTreeItemType itemType)
        {
            if (sourceTree.ItemType == itemType)
                return sourceTree;
            else
                if (sourceTree.Parent == null)
                    return sourceTree;
                else
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

        public bool IsNodeExist(Guid id)
        {
            return UnitOfWork.Repository<SourceTree>().Get(s => s.Id == id).Any();
        }
    }
}
