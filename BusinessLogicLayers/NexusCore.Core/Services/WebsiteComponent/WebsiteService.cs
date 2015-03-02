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

        #region Website

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

        public void UpdateWebsite(WebsiteModel model)
        {
            var website = PrimitiveServices.WebsitePrimitive.GetWebsite(model.Id);

            website.Name = model.Name;
            website.Description = model.Description;
            website.RootUrl = model.RootUrl;
            website.FavIconUrl = model.FavIconUrl;
            website.PageTitlePrefix = model.PageTitlePrefix;
            website.PageTitleSuffix = model.PageTitleSuffix;
            website.IsActive = model.IsActive;
            website.IsUnderMaintenance = model.IsUnderMaintenance;
            
            // update sourceTree name
            var sourceTree = AggregateServices.SourceTreeAggregate.GetSourceTreeByItemId(website.Id);
            if (sourceTree.Name != website.Name)
            {
                sourceTree.Name = website.Name;
                PrimitiveServices.SourceTreePrimitive.UpdateSourceTree(sourceTree);
            }

            PrimitiveServices.WebsitePrimitive.UpdateWebsite(website);
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

        public WebsiteModel GetWebsite(Guid websiteId)
        {
            return PrimitiveServices.WebsitePrimitive.GetWebsite(websiteId).MapTo<WebsiteModel>();
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

        #endregion

        #region Domain

        public IEnumerable<DomainModel> GetDomains(Guid websiteId)
        {
            return PrimitiveServices.DomainPrimitive.GetDomains(websiteId).MapTo<DomainModel>();
        }

        public void CreateDomain(DomainModel model)
        {
            PrimitiveServices.DomainPrimitive.CreateDomain(new Domain
            {
                WebsiteId = model.WebsiteId,
                Name = model.Name,
                IsActive = model.IsActive
            });
        }

        public void UpdateDomain(DomainModel model)
        {
            var domain = PrimitiveServices.DomainPrimitive.GetDomain(model.Id);

            if (domain.WebSite.ActivedDomainId == domain.Id && model.IsActive == false)
            {
                ErrorAdapter.ModelState.AddModelError(logCode: LogCode.ErrorWebsitePrimaryDomainCannotInactive);
                return;
            }

            domain.Name = model.Name;
            domain.IsActive = model.IsActive;

            PrimitiveServices.DomainPrimitive.UpdateDomain(domain);
        }

        public void DeleteDomain(Guid domainId)
        {
            var domain = PrimitiveServices.DomainPrimitive.GetDomain(domainId);

            if (domain.WebSite.ActivedDomainId == domain.Id)
            {
                ErrorAdapter.ModelState.AddModelError(logCode: LogCode.ErrorWebsitePrimaryDomainCannotDelete);
                return;
            }

            PrimitiveServices.DomainPrimitive.DeleteDomain(domainId);
        }

        public void SetPrimaryDomain(Guid domainId)
        {
            var domain = PrimitiveServices.DomainPrimitive.GetDomain(domainId);
            var website = domain.WebSite;

            if (website.ActivedDomainId != domain.Id)
            {
                website.ActivedDomainId = domainId;
                PrimitiveServices.WebsitePrimitive.UpdateWebsite(website);
            }            
        }

        #endregion



    }
}
