using NexusCore.Common.Data.Entities.Website;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.Websites;
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

        public void CreateDomain(DomainModel domain)
        {
            UnitOfWork.Repository<Domain>().Insert(domain.MapTo<Domain>());
        }

        public void UpdateDomain(DomainModel domain)
        {
            UnitOfWork.Repository<Domain>().Update(domain.MapTo<Domain>());
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
            return UnitOfWork.Repository<Domain>().Get(d => d.WebsiteId == websiteId);
        }

        public IEnumerable<Domain> GetLiveDomains(Guid websiteId)
        {
            return GetDomains(websiteId).Where(d => d.IsActive);
        }
    }
}
