using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NexusCore.Common.Data.Enums;
using NexusCore.Common.Services.ClientServices;
using NexusCore.Common.Services.SourceTreeServices;

namespace NexusCore.Admin.UILogic.ViewModels.Websites
{
    public class CreateWebsiteFormValue
    {
        public List<SelectListItem> Clients { get; private set; }

        public CreateWebsiteFormValue()
        {
            Clients = new List<SelectListItem>();
        }

        public void Init(ISourceTreeService sourceTreeService, IClientService clientService,
            Guid currentValue = new Guid())
        {
            var clients = clientService.GetClients(sourceTreeService.GetItemIds(SourceTreeItemType.Client));
            foreach (var client in clients)
            {
                Clients.Add(new SelectListItem
                {
                    Value = client.Id.ToString(),
                    Text = client.Name,
                    Selected = currentValue == client.Id
                });
            }
        }
    }
}
