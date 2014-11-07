using System;
using System.Collections.Generic;
using System.Linq;
using NexusCore.Common.Data.Entities.Clients;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.Clients;
using NexusCore.Common.Data.Specifications;
using NexusCore.Common.Helper.Extensions;
using NexusCore.Common.Services.ClientServices;
using NexusCore.Core.Services.Infrastructure;

namespace NexusCore.Core.Services.ClientComponent.Primitive
{
    public class ClientPrimitive : BasePrimitiveService, IClientPrimitive
    {
        public ClientPrimitive(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void CreateClient(ClientModel client)
        {
            UnitOfWork.Repository<Client>().Insert(client.MapTo<Client>());            
        }

        public void UpdateClient(ClientModel client)
        {
            UnitOfWork.Repository<Client>().Update(client.MapTo<Client>());
        }

        public void DeleteClient(Guid clientId)
        {
            UnitOfWork.Repository<Client>().Delete(clientId);
        }

        public Client GetClient(Guid clientId)
        {
            return
                UnitOfWork.Repository<Client>().Get(ClientSpecifications.GetClient(clientId)).FirstOrDefault();
        }

        public IEnumerable<Client> GetClients()
        {
            return UnitOfWork.Repository<Client>().Get();
        }
    }
}
