using System;
using System.Collections.Generic;
using System.Linq;
using NexusCore.Common.Data.Entities.SourceTrees;
using NexusCore.Common.Data.Enums;
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

        public SourceTree CreateClientNode(Guid clientId, string clientName)
        {
            var clientNode = new SourceTree
            {
                Parent = PrimitiveServices.SourceTreePrimitive.GetSourceTree(SourceTreeRoot.MasterNode.Id),
                Name = clientName,
                ItemType = SourceTreeItemType.Client,
                IsPrivacyInherited = true,
                SortOrder = 1,
            };

            clientNode.GenerateNewIdentity();

            PrimitiveServices.SourceTreePrimitive.CreateSourceTree(clientNode);
            
            UnitOfWork.Repository<ItemInSourceTree>().Insert(new ItemInSourceTree
            {
                SourceTreeId = clientNode.Id,
                ModuleType = SourceTreeItemModuleType.System,               
                ItemId = clientId
            });

            CreateClientDefaultSubNodes(clientNode);

            return clientNode;
        }

        public SourceTree CreateWebsiteNode(SourceTree websiteRoot, Guid websiteId, string websiteName)
        {
            var websiteNode = new SourceTree
            {
                Parent = websiteRoot,
                Name = websiteName,
                ItemType = SourceTreeItemType.Website,
                IsPrivacyInherited = true,
                SortOrder = 1,
            };

            websiteNode.GenerateNewIdentity();

            PrimitiveServices.SourceTreePrimitive.CreateSourceTree(websiteNode);

            UnitOfWork.Repository<ItemInSourceTree>().Insert(new ItemInSourceTree
            {
                SourceTreeId = websiteNode.Id,
                ModuleType = SourceTreeItemModuleType.System,
                ItemId = websiteId
            });

            return websiteNode;
        }

        private void CreateClientDefaultSubNodes(SourceTree client)
        {
            // Create default client sub nodes

            // Websites
            PrimitiveServices.SourceTreePrimitive.CreateSourceTree(new SourceTree
            {
                Parent = client,
                Name = "Websites",
                ItemType = SourceTreeItemType.WebsiteRoot,
                IsPrivacyInherited = true,
                SortOrder = 1,
            });
            // Modules
            PrimitiveServices.SourceTreePrimitive.CreateSourceTree(new SourceTree
            {
                Parent = client,
                Name = "Modules",
                ItemType = SourceTreeItemType.ModuleRoot,
                IsPrivacyInherited = true,
                SortOrder = 2,
            });
            // Contents
            PrimitiveServices.SourceTreePrimitive.CreateSourceTree(new SourceTree
            {
                Parent = client,
                Name = "Contents",
                ItemType = SourceTreeItemType.ContentRoot,
                IsPrivacyInherited = true,
                SortOrder = 3,
            });

        }

        public void DeleteClientNode(Guid clientId)
        {
            var item = PrimitiveServices.ItemInSourceTreePrimitive.GetItemByItemId(clientId);

            // remove item in source tree
            PrimitiveServices.ItemInSourceTreePrimitive.DeleteItemInSourceTree(item.Id);

            var sourceTreeNode = PrimitiveServices.SourceTreePrimitive.GetSourceTree(item.SourceTreeId);
            var childNodes = DeleteClientChildNodes(sourceTreeNode.ChildNodes).ToList();

            // remove child nodes
            foreach (var sourceTree in childNodes)
                PrimitiveServices.SourceTreePrimitive.DeleteSourceTree(sourceTree);                                

            // remove source tree
            PrimitiveServices.SourceTreePrimitive.DeleteSourceTree(item.SourceTreeId);
        }

        private IEnumerable<SourceTree> DeleteClientChildNodes(IEnumerable<SourceTree> sourceTrees)
        {
            foreach (var sourceTree in sourceTrees)
            {
                if (sourceTree.ChildNodes.Any())
                {
                    foreach (var childNode in DeleteClientChildNodes(sourceTree.ChildNodes))
                        yield return childNode;
                }
                yield return sourceTree;
            }
        }

        public SourceTree GetSourceTreeByItemId(Guid itemId)
        {
            return
                PrimitiveServices.SourceTreePrimitive.GetSourceTree(
                    PrimitiveServices.ItemInSourceTreePrimitive.GetSourceTreeId(itemId));
        }
    }
}
