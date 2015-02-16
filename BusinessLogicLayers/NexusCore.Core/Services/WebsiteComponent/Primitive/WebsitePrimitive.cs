using NexusCore.Common.Data.Entities.Website;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Specifications;
using NexusCore.Common.Services.WebsiteServices;
using NexusCore.Core.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NexusCore.Core.Services.WebsiteComponent.Primitive
{
    public class WebsitePrimitive: BasePrimitiveService, IWebsitePrimitive
    {
        public WebsitePrimitive(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void CreateWebsite(Website website)
        {
            UnitOfWork.Repository<Website>().Insert(website);
        }

        public void UpdateWebsite(Website website)
        {
            UnitOfWork.Repository<Website>().Update(website);
        }

        public void DeleteWebsite(Guid websiteId)
        {
            UnitOfWork.Repository<Website>().Delete(websiteId);
        }

        public Website GetWebsite(Guid websiteId)
        {
            return UnitOfWork.Repository<Website>().Get(WebsiteSpecifications.GetWebsite(websiteId)).FirstOrDefault();
        }

        public IEnumerable<Website> GetWebsites()
        {
            return UnitOfWork.Repository<Website>().Get(WebsiteSpecifications.GetWebsite());
        }

        public IEnumerable<Website> GetWebsites(IEnumerable<Guid> websiteIds)
        {
            return GetWebsites().Where(w => websiteIds.Contains(w.Id));
        }

    }
}
