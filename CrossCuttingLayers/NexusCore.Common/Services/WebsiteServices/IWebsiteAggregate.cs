using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Models.Websites;

namespace NexusCore.Common.Services.WebsiteServices
{
    public interface IWebsiteAggregate
    {
        IEnumerable<WebsiteAdminModel> GetWebsiteByClient(Guid clientId);
    }
}
