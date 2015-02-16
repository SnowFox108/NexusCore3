using NexusCore.Common.Data.Models.Clients;

namespace NexusCore.Common.Services.ClientServices
{
    public interface IClientService
    {
        void CreateClient(ClientModel client, ClientDepartmentModel department);
        ClientManagerModel GetClients(ClientSearchFilter searchFilter);
    }
}
