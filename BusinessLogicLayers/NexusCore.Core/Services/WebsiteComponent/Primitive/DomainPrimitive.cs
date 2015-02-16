using NexusCore.Common.Data.Entities.Website;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.Websites;
using NexusCore.Common.Data.Specifications;
using NexusCore.Common.Helper.Extensions;
using NexusCore.Common.Services.WebsiteServices;
using NexusCore.Core.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NexusCore.Core.Services.WebsiteComponent.Primitive
{
    public class DomainPrimitive: BasePrimitiveService, IDomainPrimitive
    {
        public DomainPrimitive(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void CreateDomain(Domain domain)
        {
            UnitOfWork.Repository<Domain>().Insert(domain);
        }

        public void UpdateDomain(Domain domain)
        {
            UnitOfWork.Repository<Domain>().Update(domain);
        }

        public void DeleteDomain(Guid domainId)
        {
            UnitOfWork.Repository<Domain>().Delete(domainId);
        }

        public Domain GetDomain(Guid domainId)
        {
            return UnitOfWork.Repository<Domain>().Get(d => d.Id == domainId).FirstOrDefault();
        }

        public IEnumerable<Domain> GetDomains(Guid websiteId)
        {
            return UnitOfWork.Repository<Domain>().Get(WebsiteSpecifications.GetDomain(websiteId));
        }

        public IEnumerable<Domain> GetDomains(string domainName)
        {
            return UnitOfWork.Repository<Domain>().Get(WebsiteSpecifications.GetDomain(domainName));
        }

        public IEnumerable<Domain> GetLiveDomains(Guid websiteId)
        {
            return GetDomains(websiteId).Where(d => d.IsActive);
        }



    }
}
