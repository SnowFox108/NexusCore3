using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Models.Websites;

namespace NexusCore.Common.Services.WebsiteServices
{
    public interface IWebsiteService
    {
        // Websites

        void CreateWebsite(WebsiteModel website, DomainModel domain, Guid clientId);
        void UpdateWebsite(WebsiteModel website);
        void DeleteWebsite(Guid websiteId);

        WebsiteModel GetWebsite(Guid websiteId);
        WebsiteManagerModel GetWebsites(WebsiteSearchFilter searchFilter);

        // Domain
        IEnumerable<DomainModel> GetDomains(Guid websiteId);
        void CreateDomain(DomainModel model);
        void UpdateDomain(DomainModel model);
        void DeleteDomain(Guid domainId);
        void SetPrimaryDomain(Guid domainId);
    }
}
