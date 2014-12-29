using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Models.Websites;

namespace NexusCore.Common.Services.WebsiteServices
{
    public interface IWebsiteAggregate
    {
        IEnumerable<DomainModel> GetDomainsByWebssite(Guid websiteId);
        IEnumerable<DomainModel> GetDomains(Guid clientId, Guid websiteId = new Guid());

        IEnumerable<WebsiteAdminModel> GetWebsiteByClient(Guid clientId);
    }
}
