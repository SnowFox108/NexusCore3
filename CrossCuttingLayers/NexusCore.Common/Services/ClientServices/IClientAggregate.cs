using NexusCore.Common.Data.Entities.Clients;

namespace NexusCore.Common.Services.ClientServices
{
    public interface IClientAggregate
    {
        void CreateClient(Client client, ClientDepartment clientDepartment);
    }
}
