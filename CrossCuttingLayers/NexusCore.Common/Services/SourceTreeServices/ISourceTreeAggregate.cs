using System;
using NexusCore.Common.Data.Entities.SourceTrees;

namespace NexusCore.Common.Services.SourceTreeServices
{
    public interface ISourceTreeAggregate
    {
        SourceTree CreateClientNode(Guid clientId, string clientName);
        SourceTree CreateWebsiteNode(SourceTree websiteRoot, Guid websiteId, string websiteName);
    }
}
