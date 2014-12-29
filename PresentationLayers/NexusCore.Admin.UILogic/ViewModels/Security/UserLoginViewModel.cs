using System.ComponentModel.DataAnnotations;
using NexusCore.Admin.UILogic.Resources;

namespace NexusCore.Admin.UILogic.ViewModels.Security
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof (AdminUIDataAnnotationText), ErrorMessageResourceName = "UserAccountRequiredEmail")]
        [Display(ResourceType = typeof(AdminUIDataAnnotationText), Name = "UserAccountDisplayEmail")]
        public string Email { get; set; }
        [Required(ErrorMessageResourceType = typeof (AdminUIDataAnnotationText), ErrorMessageResourceName = "UserAccountRequiredPassword")]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof (AdminUIDataAnnotationText), Name = "UserAccountDisplayPassword")]
        public string Password { get; set; }
        
        [Required]
        [Display(ResourceType = typeof (AdminUIDataAnnotationText), Name = "UserAccountDisplayRememberMe")]
        public bool IsRememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
