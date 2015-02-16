using NexusCore.Common.Data.Entities.Clients;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Services;
using NexusCore.Common.Services.ClientServices;
using NexusCore.Core.Services.Infrastructure;

namespace NexusCore.Core.Services.ClientComponent.Aggregate
{
    public class ClientAggregate : BaseAggregateService, IClientAggregate
    {
        public ClientAggregate(IUnitOfWork unitOfWork, IPrimitiveServices primitiveServices)
            : base(unitOfWork, primitiveServices)
        {
        }

        public void CreateClient(Client client, ClientDepartment clientDepartment)
        {
            client.GenerateNewIdentity();
            if (string.IsNullOrEmpty(client.FriendlyId))
                client.FriendlyId = PrimitiveServices.FriendlyIdPrimitive.GetFriendlyId("CL");
            clientDepartment.GenerateNewIdentity();
            clientDepartment.ClientId = client.Id;
            client.PrimaryDepartmentId = clientDepartment.Id;

            UnitOfWork.Repository<Client>().Insert(client);
            UnitOfWork.Repository<ClientDepartment>().Insert(clientDepartment);
        }
    }
}
