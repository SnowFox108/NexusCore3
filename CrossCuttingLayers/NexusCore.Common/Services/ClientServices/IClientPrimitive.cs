using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Entities.Clients;
using NexusCore.Common.Data.Models.Clients;

namespace NexusCore.Common.Services.ClientServices
{
    public interface IClientPrimitive
    {
        void UpdateClient(ClientModel client);
        void DeleteClient(Guid clientId);
        Client GetClient(Guid clientId);
        IEnumerable<Client> GetClients();
    }
}
