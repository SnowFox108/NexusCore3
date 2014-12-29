using System.ComponentModel.DataAnnotations;
using NexusCore.Admin.UILogic.Resources;

namespace NexusCore.Admin.UILogic.ViewModels.Security
{
    public class UserForgetPasswordViewModel
    {
        [Required(ErrorMessageResourceType = typeof (AdminUIDataAnnotationText), ErrorMessageResourceName = "UserAccountRequiredEmail")]
        [EmailAddress]
        [Display(ResourceType = typeof(AdminUIDataAnnotationText), Name = "UserAccountDisplayEmail")]
        public string Email { get; set; }
    }
}
