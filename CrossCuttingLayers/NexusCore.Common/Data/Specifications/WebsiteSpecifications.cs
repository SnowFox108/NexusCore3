﻿using System;
using NexusCore.Common.Data.Entities.Website;
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
    }
}