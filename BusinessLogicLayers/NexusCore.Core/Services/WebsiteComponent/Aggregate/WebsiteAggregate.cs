using NexusCore.Common.Data.Entities.SourceTrees;
using NexusCore.Common.Data.Entities.Website;
using NexusCore.Common.Data.Enums;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.Clients;
using NexusCore.Common.Data.Models.Infrastructure;
using NexusCore.Common.Data.Models.Websites;
using NexusCore.Common.Data.Specifications;
using NexusCore.Common.Helper.Extensions;
using NexusCore.Common.Services;
using NexusCore.Common.Services.WebsiteServices;
using NexusCore.Core.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NexusCore.Core.Services.WebsiteComponent.Aggregate
{
    public class WebsiteAggregate : BaseAggregateService, IWebsiteAggregate
    {
        public WebsiteAggregate(IUnitOfWork unitOfWork, IPrimitiveServices primitiveServices)
            : base(unitOfWork, primitiveServices)
        {
        }

        public void CreateWebsite(Website website, Domain domain)
        {
            website.GenerateNewIdentity();
            domain.GenerateNewIdentity();
            domain.WebsiteId = website.Id;
            website.ActivedDomainId = domain.Id;

            UnitOfWork.Repository<Website>().Insert(website);
            UnitOfWork.Repository<Domain>().Insert(domain);
        }

        public IEnumerable<DomainModel> GetDomainsByWebssite(Guid websiteId)
        {
            return PrimitiveServices.DomainPrimitive.GetDomains(websiteId).MapTo<DomainModel>();
        }

        public IEnumerable<DomainModel> GetDomains(Guid clientId, Guid websiteId = new Guid())
        {
            var websiteRootId = GetWebsiteRootByClientId(clientId);

            return from sourceTreeNodes in PrimitiveServices.SourceTreePrimitive.GetWebsiteNodes(websiteRootId)
                   join itemsInSourceTree in UnitOfWork.Repository<ItemInSourceTree>().Get()
                       on sourceTreeNodes.Id equals itemsInSourceTree.SourceTreeId
                   join websites in PrimitiveServices.WebsitePrimitive.GetWebsites()
                       on itemsInSourceTree.ItemId equals websites.Id
                   join domains in PrimitiveServices.DomainPrimitive.GetDomains(websiteId)
                       on websites.Id equals domains.WebsiteId
                   select domains.MapTo<DomainModel>();

        }

        public int GetWebsiteCount(WebsiteSearchFilter searchFilter,
            IEnumerable<Guid> websitesInClientIds)
        {
            return UnitOfWork.Repository<Website>()
                .Get(WebsiteSpecifications.GetWebsite(searchFilter,
                    PrimitiveServices.DomainPrimitive.GetDomains(searchFilter.DomainName),
                    websitesInClientIds)).Count();
        }

        public IEnumerable<WebsiteAdminModel> GetWebsites(WebsiteSearchFilter searchFilter,
            IEnumerable<Guid> websitesInClientIds)
        {
            var websites = UnitOfWork.Repository<Website>()
                .Get(WebsiteSpecifications.GetWebsite(searchFilter,
                    PrimitiveServices.DomainPrimitive.GetDomains(searchFilter.DomainName),
                    websitesInClientIds),
                    u => u.OrderBy(searchFilter.Filter.Sorting.SortOrder, searchFilter.Filter.Sorting.SortDirection),
                    pageNumber: searchFilter.Filter.Paging.CurrentPage,
                    pageSize: searchFilter.Filter.Paging.ItemsPerPage).ToList();

            foreach (var website in websites)
            {
                var client =
                    PrimitiveServices.ClientPrimitive.GetClient(PrimitiveServices.ItemInSourceTreePrimitive.GetItem(
                        PrimitiveServices.SourceTreePrimitive.GetParentNode(
                            PrimitiveServices.ItemInSourceTreePrimitive.GetSourceTreeId(website.Id),
                            SourceTreeItemType.Client).Id).ItemId);

                yield return new WebsiteAdminModel
                {
                    Website = PrimitiveServices.UserPrimitive.MapToTrackableUser<WebsiteModel>(website.MapTo<WebsiteModel>()),
                    Client = client.MapTo<ClientModel>()
                };
            }
                        
            
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

        private SourceTree GetWebsiteRootByClientId(Guid clientId)
        {
            return PrimitiveServices.SourceTreePrimitive.GetWebsiteRoot(
                    PrimitiveServices.ItemInSourceTreePrimitive.GetSourceTreeId(clientId));
        }

    }
}
