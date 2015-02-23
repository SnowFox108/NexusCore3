using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Entities.Clients;
using NexusCore.Common.Data.Models.Clients;

namespace NexusCore.Common.Services.ClientServices
{
    public interface IClientPrimitive
    {
        void CreateClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(Guid clientId);
        Client GetClient(Guid clientId);

        int GetClientCount(ClientSearchFilter searchFilter);
        IEnumerable<Client> GetClients();
        IEnumerable<Client> GetClients(ClientSearchFilter searchFilter);
        IEnumerable<Client> GetClients(IEnumerable<Guid> clientIds);
    }
}
