
using System.ComponentModel.DataAnnotations;
using NexusCore.Common.Resources;

namespace NexusCore.Common.Data.Models.Installation
{
    public class InstallationAdministratorModel
    {
        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "GeneralRequiredTitle")]
        public string Title { get; set; }

        public string UserName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        [Required(ErrorMessageResourceType = typeof (DataAnnotationText), ErrorMessageResourceName = "GeneralRequiredEmail")]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof (DataAnnotationText), ErrorMessageResourceName = "GeneralRequiredValidEmail")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof (DataAnnotationText), ErrorMessageResourceName = "GeneralRequiredFirstname")]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof (DataAnnotationText), ErrorMessageResourceName = "GeneralRequiredLastname")]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "GeneralRequiredNewPassword")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=(.*\d){1})(?=.*[a-zA-Z])[0-9a-zA-Z!@#$%]{8,}", ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "GeneralValidationNewPassword")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "GeneralComparePassword")]
        [Display(ResourceType = typeof(DataAnnotationText), Name = "GeneralDisplayConfirmPassword")]
        public string ConfirmPassword { get; set; }
    }
}
