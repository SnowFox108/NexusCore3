using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Entities.Website;

namespace NexusCore.Common.Services.WebsiteServices
{
    public interface IDomainPrimitive
    {
        void CreateDomain(Domain domain);
        void UpdateDomain(Domain domain);
        void DeleteDomain(Guid domainId);
        Domain GetDomain(Guid domainId);
        IEnumerable<Domain> GetDomains(Guid websiteId);
        IEnumerable<Domain> GetDomains(string domainName);
        IEnumerable<Domain> GetLiveDomains(Guid websiteId);

    }
}
