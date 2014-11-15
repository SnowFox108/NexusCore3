using NexusCore.Common.Data.Entities.SourceTrees;
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
    }
}
