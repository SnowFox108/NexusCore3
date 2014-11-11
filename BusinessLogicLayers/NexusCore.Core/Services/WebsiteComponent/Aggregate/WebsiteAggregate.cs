﻿using System;
using System.Collections.Generic;
using System.Linq;
using NexusCore.Common.Data.Entities.SourceTrees;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.Clients;
using NexusCore.Common.Data.Models.Websites;
using NexusCore.Common.Helper.Extensions;
using NexusCore.Common.Services;
using NexusCore.Common.Services.WebsiteServices;
using NexusCore.Core.Services.Infrastructure;

namespace NexusCore.Core.Services.WebsiteComponent.Aggregate
{
    public class WebsiteAggregate : BaseAggregateService, IWebsiteAggregate
    {
        public WebsiteAggregate(IUnitOfWork unitOfWork, IPrimitiveServices primitiveServices) : base(unitOfWork, primitiveServices)
        {
        }

        public IEnumerable<WebsiteAdminModel> GetWebsiteByClient(Guid clientId)
        {
            var websiteRootId = GetWebsiteRootByClientId(clientId);
            var client = PrimitiveServices.ClientPrimitive.GetClient(clientId).MapTo<ClientModel>();

            return from sourceTreeNodes in PrimitiveServices.SourceTreePrimitive.GetWebsiteNodes(websiteRootId)
                join itemsInSourceTree in UnitOfWork.Repository<ItemInSourceTree>().Get()
                    on sourceTreeNodes.Id equals itemsInSourceTree.SourceTreeId
                join websites in PrimitiveServices.WebsitePrimitive.GetWebsites()
                    on itemsInSourceTree.ItemId equals websites.Id
                select new WebsiteAdminModel
                {
                    Website = websites.MapTo<WebsiteModel>(),
                    Client = client
                };
        }

        private Guid GetWebsiteRootByClientId(Guid clientId)
        {
            return PrimitiveServices.SourceTreePrimitive.GetWebsiteRoot(
                    PrimitiveServices.ItemInSourceTreePrimitive.GetSourceTreeId(clientId)).Id;            
        }
    }
}
