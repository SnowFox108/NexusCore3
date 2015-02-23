using System;
using NexusCore.Common.Data.Entities.SourceTrees;

namespace NexusCore.Common.Services.SourceTreeServices
{
    public interface ISourceTreeAggregate
    {
        SourceTree CreateClientNode(Guid clientId, string clientName);
        SourceTree CreateWebsiteNode(SourceTree websiteRoot, Guid websiteId, string websiteName);

        void DeleteClientNode(Guid clientId);

        /// <summary>
        /// Get SourceTree item by itemId in ItemsInSourceTree table
        /// </summary>
        /// <param name="itemId">itemId</param>
        /// <returns>SourceTree</returns>
        SourceTree GetSourceTreeByItemId(Guid itemId);
    }
}
