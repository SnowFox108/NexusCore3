using System;
using NexusCore.Common.Data.Models.Websites;

namespace NexusCore.Common.Services.WebsiteServices
{
    public interface IWebsiteService
    {
        void CreateWebsite(WebsiteModel website, DomainModel domain, Guid clientId);
        void UpdateWebsite(WebsiteModel website);
        void DeleteWebsite(Guid websiteId);

        WebsiteModel GetWebsite(Guid websiteId);
        WebsiteManagerModel GetWebsites(WebsiteSearchFilter searchFilter);
    }
}
