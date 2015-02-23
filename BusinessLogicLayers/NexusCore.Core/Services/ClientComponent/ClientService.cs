using System;
using System.Collections.Generic;
using System.Linq;
using NexusCore.Common.Adapter.ErrorHandlers;
using NexusCore.Common.Data.Entities.Clients;
using NexusCore.Common.Data.Enums;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.Clients;
using NexusCore.Common.Helper.Extensions;
using NexusCore.Common.Services;
using NexusCore.Common.Services.ClientServices;
using NexusCore.Core.Services.Infrastructure;
using NexusCore.Infrasructure.Models.Enums;

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

        public void DeleteClient(Guid clientId)
        {
            ClientHasContent(clientId);
            if (ErrorAdapter.ModelState.IsValid)
            {
                PrimitiveServices.ClientPrimitive.DeleteClient(clientId);
                AggregateServices.SourceTreeAggregate.DeleteClientNode(clientId);
                UnitOfWork.SaveChanges();
            }
        }

        private void ClientHasContent(Guid clientId)
        {
            if (
                PrimitiveServices.SourceTreePrimitive.GetSourceTreeNodes(
                    PrimitiveServices.ItemInSourceTreePrimitive.GetSourceTreeId(clientId),
                    Common.Data.Enums.SourceTreeItemType.Website).Any())
                ErrorAdapter.ModelState.AddModelError(logCode: LogCode.ErrorClientCannotDeleteDueHasWebsite);
        }

        public ClientModel GetClient(Guid clientId)
        {
            return PrimitiveServices.ClientPrimitive.GetClient(clientId).MapTo<ClientModel>();
        }


        public ClientModel GetClientByWebsiteId(Guid websiteId)
        {
            return PrimitiveServices.ClientPrimitive.GetClient(
                PrimitiveServices.ItemInSourceTreePrimitive.GetItem(
                    PrimitiveServices.SourceTreePrimitive.GetParentNode(
                        PrimitiveServices.ItemInSourceTreePrimitive.GetSourceTreeId(websiteId),
                        SourceTreeItemType.Client)).ItemId).MapTo<ClientModel>();
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

        public IEnumerable<ClientModel> GetClients(IEnumerable<Guid> clientIds)
        {
            return PrimitiveServices.ClientPrimitive.GetClients(clientIds).MapTo<ClientModel>();
        }

        public void UpdateClient(ClientModel model)
        {
            var client = PrimitiveServices.ClientPrimitive.GetClient(model.Id);

            client.Name = model.Name;
            client.Description = model.Description;
            client.LogoUrl = model.LogoUrl;
            client.IsActive = model.IsActive;

            PrimitiveServices.ClientPrimitive.UpdateClient(client);
            UnitOfWork.SaveChanges();
        }

    }
}
