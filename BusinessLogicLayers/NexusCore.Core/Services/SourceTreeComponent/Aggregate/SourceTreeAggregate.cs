using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Entities.SourceTrees;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.SourceTrees;
using NexusCore.Common.Services;
using NexusCore.Common.Services.SourceTreeServices;
using NexusCore.Core.Services.Infrastructure;

namespace NexusCore.Core.Services.SourceTreeComponent.Aggregate
{
    public class SourceTreeAggregate : BaseAggregateService, ISourceTreeAggregate
    {
        public SourceTreeAggregate(IUnitOfWork unitOfWork, IPrimitiveServices primitiveServices) : base(unitOfWork, primitiveServices)
        {
        }

        public void CreateClientNode(Guid clientId, string clientName)
        {
            var clientNode = new SourceTree
            {
                ParentId = SourceTreeRoot.MasterNode.Id,
                Name = clientName,
                ItemType = SourceTreeItemType.Client,
                SortOrder = 1,
            };

            clientNode.GenerateNewIdentity();

            CreateNode(clientNode);
            
            UnitOfWork.Repository<ItemInSourceTree>().Insert(new ItemInSourceTree()
            {
                SourceTreeId = clientNode.Id,
                ModuleType = SourceTreeItemModuleType.System,
                ItemId = clientId
            });

            CreateClientDefaultSubNodes(clientNode.Id);

        }

        private void CreateClientDefaultSubNodes(Guid clientId)
        {
            // Create default client sub nodes

            // Websites
            CreateNode(new SourceTree
            {
                ParentId = clientId,
                Name = "Websites",
                ItemType = SourceTreeItemType.WebsiteRoot,
                SortOrder = 1,
            });
            // Modules
            CreateNode(new SourceTree
            {
                ParentId = clientId,
                Name = "Modules",
                ItemType = SourceTreeItemType.ModuleRoot,
                SortOrder = 2,
            });
            // Contents
            CreateNode(new SourceTree
            {
                ParentId = clientId,
                Name = "Contents",
                ItemType = SourceTreeItemType.ContentRoot,
                SortOrder = 3,
            });

        }

        private void CreateNode(SourceTree sourceTree)
        {
            UnitOfWork.Repository<SourceTree>().Insert(sourceTree);
        }


    }
}
