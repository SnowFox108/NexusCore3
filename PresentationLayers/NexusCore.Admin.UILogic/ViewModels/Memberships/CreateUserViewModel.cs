
using System;
using System.ComponentModel.DataAnnotations;
using NexusCore.Admin.UILogic.Resources;
using NexusCore.Common.Data.Models.Memberships;

namespace NexusCore.Admin.UILogic.ViewModels.Memberships
{
    public class CreateUserViewModel
    {
        public CreateUserInfoFormValue FormValue { get; set; }
        public UserModel User { get; set; }

        [Display(ResourceType = typeof(AdminUIDataAnnotationText), Name = "UserAccountDisplayWebsite")]
        public Guid RegistedWebsiteId { get; set; }

        public CreateUserViewModel()
        {
            FormValue = new CreateUserInfoFormValue();
        }
    }
}
