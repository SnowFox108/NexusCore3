using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NexusCore.Common.Services.SourceTreeServices;
using NexusCore.Common.Services.WebsiteServices;

namespace NexusCore.Admin.UILogic.ViewModels.Memberships
{
    public class CreateUserInfoFormValue : UserInfoFormValue
    {
        public List<SelectListItem> Website { get; private set; }

        public CreateUserInfoFormValue()
        {
            Website = new List<SelectListItem>();
        }

        public void Init(ISourceTreeService sourceTreeService, IWebsitePrimitive websiteService, Guid currentValue = new Guid())
        {
            base.Init();

            var websties = websiteService.GetWebsites(sourceTreeService.GetWebsiteIds().ToList());
            foreach (var website in websties)
            {
                Website.Add(new SelectListItem
                {
                    Value = website.Id.ToString(),
                    Text = website.Name,
                    Selected = currentValue == website.Id
                });
            }
        }

    }
}
