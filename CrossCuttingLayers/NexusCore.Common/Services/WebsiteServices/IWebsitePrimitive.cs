﻿using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Entities.Website;
using NexusCore.Common.Data.Models.Websites;

namespace NexusCore.Common.Services.WebsiteServices
{
    public interface IWebsitePrimitive
    {
        void UpdateWebsite(WebsiteModel website);
        void DeleteWebsite(Guid websiteId);
        Website GetWebsite(Guid websiteId);
        IEnumerable<Website> GetWebsites();
    }
}
