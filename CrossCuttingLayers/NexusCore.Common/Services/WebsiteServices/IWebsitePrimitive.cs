using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Entities.Website;

namespace NexusCore.Common.Services.WebsiteServices
{
    public interface IWebsitePrimitive
    {
        void CreateWebsite(Website website);
        void UpdateWebsite(Website website);
        void DeleteWebsite(Guid websiteId);
        Website GetWebsite(Guid websiteId);
        IEnumerable<Website> GetWebsites();
        IEnumerable<Website> GetWebsites(IEnumerable<Guid> websiteIds);
    }
}
