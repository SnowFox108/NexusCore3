using System.ComponentModel.DataAnnotations;
using NexusCore.Admin.UILogic.Resources;

namespace NexusCore.Admin.UILogic.ViewModels.Memberships
{
    public class UserViewModel
    {
        [Required(ErrorMessageResourceType = typeof(AdminUIDataAnnotationText), ErrorMessageResourceName = "UserAccountRequiredEmail")]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(AdminUIDataAnnotationText), ErrorMessageResourceName = "UserAccountValidationEmail")]
        [Display(ResourceType = typeof(AdminUIDataAnnotationText), Name = "UserAccountDisplayEmail")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(AdminUIDataAnnotationText), ErrorMessageResourceName = "UserAccountRequiredTitle")]
        [Display(ResourceType = typeof(AdminUIDataAnnotationText), Name = "UserAccountDisplayTitle")]
        public string Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(AdminUIDataAnnotationText), ErrorMessageResourceName = "UserAccountRequiredFirstName")]
        [Display(ResourceType = typeof(AdminUIDataAnnotationText), Name = "UserAccountDisplayFirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(AdminUIDataAnnotationText), ErrorMessageResourceName = "UserAccountRequiredLastName")]
        [Display(ResourceType = typeof(AdminUIDataAnnotationText), Name = "UserAccountDisplayLastName")]
        public string LastName { get; set; }

        [Display(ResourceType = typeof(AdminUIDataAnnotationText), Name = "UserAccountDisplayUserName")]
        public string UserName { get; set; }

        [Display(ResourceType = typeof(AdminUIDataAnnotationText), Name = "UserAccountDisplayPhoneNumber")]
        public string PhoneNumber { get; set; }

    }
}
