using System;
using System.ComponentModel.DataAnnotations;
using NexusCore.Common.Data.Models.Websites;
using NexusCore.Common.Resources;

namespace NexusCore.Admin.UILogic.ViewModels.Websites
{
    public class CreateWebsiteViewModel
    {
        public CreateWebsiteFormValue FormValue { get; set; }
        public WebsiteModel Website { get; set; }
        public DomainModel Domain { get; set; }

        [Display(ResourceType = typeof(DataAnnotationText), Name = "ClientDisplaySelect")]
        public Guid ClientId { get; set; }

        public CreateWebsiteViewModel()
        {
            FormValue = new CreateWebsiteFormValue();
        }
    }
}
