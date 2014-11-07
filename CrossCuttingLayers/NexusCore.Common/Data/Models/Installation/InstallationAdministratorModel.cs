
using System.ComponentModel.DataAnnotations;
using NexusCore.Common.Resources;

namespace NexusCore.Common.Data.Models.Installation
{
    public class InstallationAdministratorModel
    {
        [Required(ErrorMessageResourceType = typeof (DataAnnotationText), ErrorMessageResourceName = "InstallationAdministratorRequiredTitle")]
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
    }
}
