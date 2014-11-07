using NexusCore.Common.Data.Entities.Clients;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.Clients;
using NexusCore.Common.Helper.Extensions;
using NexusCore.Common.Services;
using NexusCore.Common.Services.ClientServices;
using NexusCore.Core.Services.Infrastructure;

namespace NexusCore.Core.Services.ClientComponent
{
    public class ClientService : BaseComponentService, IClientService
    {
        public ClientService(IUnitOfWork unitOfWork, IPrimitiveServices primitiveServices, IAggregateServices aggregateServices) : base(unitOfWork, primitiveServices, aggregateServices)
        {
        }

        
        public void CreateClient(ClientCreateModel client)
        {
            client.Client.GenerateNewIdentity();
            client.ClientDepartment.GenerateNewIdentity();

            AggregateServices.ClientAggregate.CreateClient(client.Client.MapTo<Client>(),
                client.ClientDepartment.MapTo<ClientDepartment>());
            AggregateServices.SourceTreeAggregate.CreateClientNode(client.Client.Id, client.Client.Name);            
        }
    }
}
