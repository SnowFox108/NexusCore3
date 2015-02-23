using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Models.Clients;

namespace NexusCore.Common.Services.ClientServices
{
    public interface IClientService
    {
        void CreateClient(ClientModel client, ClientDepartmentModel department);
        void DeleteClient(Guid clientId);
        ClientModel GetClient(Guid clientId);
        ClientModel GetClientByWebsiteId(Guid websiteId);
        ClientManagerModel GetClients(ClientSearchFilter searchFilter);
        IEnumerable<ClientModel> GetClients(IEnumerable<Guid> clientIds);
        void UpdateClient(ClientModel client);
    }
}
