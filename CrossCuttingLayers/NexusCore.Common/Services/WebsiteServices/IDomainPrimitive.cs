using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Entities.Website;
using NexusCore.Common.Data.Models.Websites;

namespace NexusCore.Common.Services.WebsiteServices
{
    public interface IDomainPrimitive
    {
        void CreateDomain(DomainModel domain);
        void UpdateDomain(DomainModel domain);
        void DeleteDomain(Guid domainId);
        Domain GetDomain(Guid domainId);
        IEnumerable<Domain> GetDomains(Guid websiteId);
        IEnumerable<Domain> GetLiveDomains(Guid websiteId);
    }
}
