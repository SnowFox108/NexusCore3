using System;
using NexusCore.Common.Data.Models.Clients;
using NexusCore.Common.Services.ClientServices;

namespace NexusCore.Admin.UILogic.ViewModels.Clients
{
    public class EditClientViewModel
    {
        public ClientModel Client { get; set; }

        public void InitData(IClientService client, Guid clientId)
        {
            Client = client.GetClient(clientId);
        }
    }
}
