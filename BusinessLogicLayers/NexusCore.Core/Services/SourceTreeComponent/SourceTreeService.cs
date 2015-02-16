using System.Collections.Generic;
using System.Linq;
using NexusCore.Common.Data.Entities.SourceTrees;
using NexusCore.Common.Data.Enums;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.SourceTrees;
using NexusCore.Common.Data.Values.SourceTree;
using NexusCore.Common.Services;
using NexusCore.Common.Services.SourceTreeServices;
using NexusCore.Core.Services.Infrastructure;
using System;

namespace NexusCore.Core.Services.SourceTreeComponent
{
    public class SourceTreeService : BaseComponentService, ISourceTreeService
    {
        public SourceTreeService(IUnitOfWork unitOfWork, IPrimitiveServices primitiveServices,
            IAggregateServices aggregateServices) : base(unitOfWork, primitiveServices, aggregateServices)
        {
        }

        public IEnumerable<Guid> GetClientNodeIds()
        {
            return GetClientNodes().Select(c => c.Id);
        }

        public IEnumerable<SourceTree> GetClientNodes()
        {
            return GetSourceTreeNodes(SourceTreeItemType.Client);
        }

        public IEnumerable<Guid> GetWebsiteIds()
        {
            return
                PrimitiveServices.ItemInSourceTreePrimitive.GetItems(GetWebsiteNodes().Select(n => n.Id).ToList())
                    .Select(i => i.ItemId);
        }

        public IEnumerable<SourceTree> GetWebsiteNodes()
        {
            //var clientNodes = GetClientNodes();
            //foreach (var clientNode in clientNodes)
            //{
            //    var websites =
            //        PrimitiveServices.SourceTreePrimitive.GetChildNodes(
            //            PrimitiveServices.SourceTreePrimitive.GetWebsiteRoot(clientNode.Id));

            //    foreach (var website in websites)
            //    {
            //        if (AggregateServices.PermissionAggregate.CanView(website.Id))
            //            yield return website;
            //    }
            //}
            return GetSourceTreeNodes(SourceTreeItemType.Website);
        }

        public SourceTreeModel GetSourceTreeBuild()
        {
            var sourceTree = GetSourceTreeModel(SourceTreeRoot.MasterNode, new Guid());
            BuildChildNodes(sourceTree);
            return sourceTree;
        }


        private void BuildChildNodes(SourceTreeModel parentNode)
        {
            var childNodes = PrimitiveServices.SourceTreePrimitive.GetChildNodes(parentNode.Id);
            foreach (var sourceTree in childNodes)
            {
                if (AggregateServices.PermissionAggregate.CanView(sourceTree.Id))
                {
                    var sourceTreeModel = GetSourceTreeModel(sourceTree, parentNode.Id);
                    parentNode.ChildNodes.Add(sourceTreeModel);
                    BuildChildNodes(sourceTreeModel);
                }
            }
        }

        private SourceTreeModel GetSourceTreeModel(SourceTree sourceTree, Guid parentId)
        {
            return new SourceTreeModel
            {
                Id = sourceTree.Id,
                ParentId = parentId,
                Name = sourceTree.Name,
                SortOrder = sourceTree.SortOrder,
                ItemType = sourceTree.ItemType.Value()
            };
        }

        public IEnumerable<SourceTree> GetSourceTreeNodes(SourceTreeItemType itemType)
        {
            return VerifyChildNodes(SourceTreeRoot.MasterNode, itemType);
        }

        private IEnumerable<SourceTree> VerifyChildNodes(SourceTree parentNode, SourceTreeItemType itemType)
        {
            var childNodes = PrimitiveServices.SourceTreePrimitive.GetChildNodes(parentNode.Id);
            foreach (var sourceTree in childNodes)
            {
                if (AggregateServices.PermissionAggregate.CanView(sourceTree.Id))
                {
                    if (sourceTree.ItemType == itemType)
                        yield return sourceTree;
                        //sourceTrees.Add(sourceTree);
                    foreach (var item in VerifyChildNodes(sourceTree, itemType))
                        yield return item;
                }
            }
        }

    }
}
