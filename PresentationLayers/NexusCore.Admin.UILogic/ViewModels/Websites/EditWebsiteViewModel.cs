using System;
using NexusCore.Common.Data.Models.Clients;
using NexusCore.Common.Data.Models.Websites;
using NexusCore.Common.Services.ClientServices;
using NexusCore.Common.Services.WebsiteServices;

namespace NexusCore.Admin.UILogic.ViewModels.Websites
{
    public class EditWebsiteViewModel
    {
        public WebsiteModel Website { get; set; }
        public ClientModel Client { get; set; }

        public void InitData(IWebsiteService websiteService, IClientService clientService, Guid websiteId)
        {
            Website = websiteService.GetWebsite(websiteId);
            Client = clientService.GetClientByWebsiteId(websiteId);
        }
    }
}
