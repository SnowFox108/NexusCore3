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
    public class WebsitePrimitive: BasePrimitiveService, IWebsitePrimitive
    {
        public WebsitePrimitive(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void UpdateWebsite(WebsiteModel website)
        {
            UnitOfWork.Repository<Website>().Update(website.MapTo<Website>());
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
    }
}
