using System;
using System.Collections.Generic;
using System.Linq;
using NexusCore.Common.Data.Entities.Website;
using NexusCore.Common.Data.Models.Websites;
using NexusCore.Common.Data.Specification;
using NexusCore.Common.Infrastructure;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Specifications
{
    public class WebsiteSpecifications
    {

        public static ISpecification<Domain> GetDomain(Guid websiteId = new Guid())
        {
            Specification<Domain> spec = new TrueSpecification<Domain>();
            if (websiteId != default(Guid))
                spec &= new DirectSpecification<Domain>(d => d.WebsiteId == websiteId);
            if (!EngineContext.Instance.CurrentUser.IsAdmin)
                spec &= new DirectSpecification<Domain>(d => d.IsActive);

            return spec;
        }

        public static ISpecification<Domain> GetDomain(string domainName)
        {
            Specification<Domain> spec = new TrueSpecification<Domain>();
            if (!string.IsNullOrEmpty(domainName))
                spec &= new DirectSpecification<Domain>(d => d.Name.Contains(domainName));
            if (!EngineContext.Instance.CurrentUser.IsAdmin)
                spec &= new DirectSpecification<Domain>(d => d.IsActive);

            return spec;
        }
        public static ISpecification<Website> GetWebsite()
        {
            Specification<Website> spec = new TrueSpecification<Website>();
            if (!EngineContext.Instance.CurrentUser.IsAdmin)
                spec &= new DirectSpecification<Website>(w => w.IsActive);

            return spec;
        }

        public static ISpecification<Website> GetWebsite(Guid websiteId)
        {
            Specification<Website> spec = new TrueSpecification<Website>();

            spec &= new DirectSpecification<Website>(w => w.Id == websiteId);

            if (!EngineContext.Instance.CurrentUser.IsAdmin)
                spec &= new DirectSpecification<Website>(w => w.IsActive);

            return spec;
        }

        public static ISpecification<Website> GetWebsite(WebsiteSearchFilter searchFilter, IEnumerable<Domain> domains, IEnumerable<Guid> websitesInClientIds)
        {
            Specification<Website> spec = new TrueSpecification<Website>();

            if (!string.IsNullOrEmpty(searchFilter.FriendlyId))
                spec &= new DirectSpecification<Website>(w => w.FriendlyId.Contains(searchFilter.FriendlyId));
            if (!string.IsNullOrEmpty(searchFilter.Name))
                spec &= new DirectSpecification<Website>(w => w.Name.Contains(searchFilter.Name));
            if (!string.IsNullOrEmpty(searchFilter.DomainName))
            {
                var domainIds = domains.Select(d => d.WebsiteId);
                spec &= new DirectSpecification<Website>(w => domainIds.Contains(w.Id));
            }
            if (searchFilter.ClientId != Guid.Empty)
                spec &= new DirectSpecification<Website>(w => websitesInClientIds.Contains(w.Id));

            return spec;
        }
    }
}
