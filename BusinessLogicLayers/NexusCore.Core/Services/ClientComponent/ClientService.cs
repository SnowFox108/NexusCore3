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

        
        public void CreateClient(ClientModel client, ClientDepartmentModel department)
        {
            client.GenerateNewIdentity();
            department.GenerateNewIdentity();

            AggregateServices.ClientAggregate.CreateClient(client.MapTo<Client>(),
                department.MapTo<ClientDepartment>());
            AggregateServices.SourceTreeAggregate.CreateClientNode(client.Id, client.Name);
            
            UnitOfWork.SaveChanges();
        }


        public ClientManagerModel GetClients(ClientSearchFilter searchFilter)
        {
            return new ClientManagerModel
            {
                Clients = PrimitiveServices.UserPrimitive.MapToTrackableUser<ClientModel>(PrimitiveServices.ClientPrimitive.GetClients(searchFilter).MapTo<ClientModel>()),
                Paging = new Common.Data.Models.CommonModels.PaginationModel
                {
                    TotalItems = PrimitiveServices.ClientPrimitive.GetClientCount(searchFilter),
                    ItemsPerPage = searchFilter.Filter.Paging.ItemsPerPage,
                    CurrentPage = searchFilter.Filter.Paging.CurrentPage
                }
            };
        }
    }
}
