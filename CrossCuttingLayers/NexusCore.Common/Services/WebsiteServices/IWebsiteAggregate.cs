using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Entities.Website;
using NexusCore.Common.Data.Models.Websites;

namespace NexusCore.Common.Services.WebsiteServices
{
    public interface IWebsiteAggregate
    {
        void CreateWebsite(Website website, Domain domain);
        IEnumerable<DomainModel> GetDomainsByWebssite(Guid websiteId);
        IEnumerable<DomainModel> GetDomains(Guid clientId, Guid websiteId = new Guid());

        int GetWebsiteCount(WebsiteSearchFilter searchFilter,
            IEnumerable<Guid> websitesInClientIds);

        IEnumerable<WebsiteAdminModel> GetWebsites(WebsiteSearchFilter searchFilter,
            IEnumerable<Guid> websitesInClientIds);

        IEnumerable<WebsiteAdminModel> GetWebsiteByClient(Guid clientId);
    }
}
