using System.ComponentModel.DataAnnotations;
using NexusCore.Admin.UILogic.Resources;

namespace NexusCore.Admin.UILogic.ViewModels.Security
{
    public class UserActivationViewModel
    {
        [Required(ErrorMessageResourceType = typeof (AdminUIDataAnnotationText), ErrorMessageResourceName = "UserAccountRequiredActivationToken")]
        [Display(ResourceType = typeof (AdminUIDataAnnotationText), Name = "UserAccountDisplayActivationToken")]
        public string Token { get; set; }

        [Required(ErrorMessageResourceType = typeof (AdminUIDataAnnotationText), ErrorMessageResourceName = "UserAccountRequiredNewPassword")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=(.*\d){1})(?=.*[a-zA-Z])[0-9a-zA-Z!@#$%]{8,}", ErrorMessageResourceType = typeof(AdminUIDataAnnotationText), ErrorMessageResourceName="UserAccountValidationNewPassword")]
        [Display(ResourceType = typeof (AdminUIDataAnnotationText), Name = "UserAccountDisplayNewPassword")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessageResourceType = typeof (AdminUIDataAnnotationText), ErrorMessageResourceName = "UserAccountComparePassword")]
        [Display(ResourceType = typeof (AdminUIDataAnnotationText), Name = "UserAccountDisplayConfirmPassword")]
        public string ConfirmPassword { get; set; }

    }
}
