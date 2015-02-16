using NexusCore.Common.Adapter.ErrorHandlers;
using NexusCore.Common.Data.Entities.Website;
using NexusCore.Common.Data.Enums;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.CommonModels;
using NexusCore.Common.Data.Models.Websites;
using NexusCore.Common.Helper.Extensions;
using NexusCore.Common.Services;
using NexusCore.Common.Services.WebsiteServices;
using NexusCore.Core.Services.Infrastructure;
using NexusCore.Infrasructure.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NexusCore.Core.Services.WebsiteComponent
{
    public class WebsiteService : BaseComponentService, IWebsiteService
    {
        public WebsiteService(IUnitOfWork unitOfWork, IPrimitiveServices primitiveServices,
            IAggregateServices aggregateServices)
            : base(unitOfWork, primitiveServices, aggregateServices)
        {
        }

        public void CreateWebsite(WebsiteModel website, DomainModel domain, Guid clientId)
        {
            website.GenerateNewIdentity();
            domain.GenerateNewIdentity();

            AggregateServices.WebsiteAggregate.CreateWebsite(website.MapTo<Website>(), domain.MapTo<Domain>());

            var clientNode = AggregateServices.SourceTreeAggregate.GetSourceTreeByItemId(clientId);

            if (clientNode == null)
            {
                ErrorAdapter.ModelState.AddModelError(logCode: LogCode.CriticalItemIdNotInSourceTree);
                return;
            }

            AggregateServices.SourceTreeAggregate.CreateWebsiteNode(
                PrimitiveServices.SourceTreePrimitive.GetWebsiteRoot(clientNode),
                website.Id, website.Name);
        }

        public void UpdateWebsite(WebsiteModel website)
        {
            PrimitiveServices.WebsitePrimitive.UpdateWebsite(website.MapTo<Website>());
        }

        public void DeleteWebsite(Guid websiteId)
        {
            throw new NotImplementedException();
            //TODO check if website is empty
            //TODO remove from sourceTree
            //TODO remove all domains
            //TODO remove all settings
            //TODO remove website
        }

        public WebsiteManagerModel GetWebsites(WebsiteSearchFilter searchFilter)
        {
            var websitesInClientIds =
                AggregateServices.ItemInSourceTreeAggregate.GetItemsInSourceTree(searchFilter.ClientId,
                    SourceTreeItemType.Website).Select(i => i.ItemId).ToArray();

            return new WebsiteManagerModel
            {
                Websites = AggregateServices.WebsiteAggregate.GetWebsites(searchFilter, websitesInClientIds),
                Paging = new PaginationModel
                {
                    TotalItems = AggregateServices.WebsiteAggregate.GetWebsiteCount(searchFilter, websitesInClientIds),
                    ItemsPerPage = searchFilter.Filter.Paging.ItemsPerPage,
                    CurrentPage = searchFilter.Filter.Paging.CurrentPage
                }
            };
        }
    }
}
