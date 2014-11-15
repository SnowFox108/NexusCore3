using System;

namespace NexusCore.Common.Services.SourceTreeServices
{
    public interface ISourceTreeAggregate
    {
        void CreateClientNode(Guid clientId, string clientName);
    }
}
