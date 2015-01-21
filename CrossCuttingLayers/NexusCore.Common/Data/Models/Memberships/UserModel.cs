using System;
using System.ComponentModel.DataAnnotations;
using NexusCore.Common.Data.Models.Infrastructure;
using NexusCore.Common.Resources;

namespace NexusCore.Common.Data.Models.Memberships
{
    public class UserModel : TrackableModel
    {
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "GeneralRequiredEmail")]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "GeneralRequiredValidEmail")]
        [Display(ResourceType = typeof(DataAnnotationText), Name = "GeneralDisplayEmail")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "GeneralRequiredTitle")]
        [Display(ResourceType = typeof(DataAnnotationText), Name = "GeneralDisplayTitle")]
        public string Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "GeneralRequiredFirstname")]
        [Display(ResourceType = typeof(DataAnnotationText), Name = "GeneralDisplayFirstName")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "GeneralRequiredLastname")]
        [Display(ResourceType = typeof(DataAnnotationText), Name = "GeneralDisplayLastName")]
        public string LastName { get; set; }

        [Display(ResourceType = typeof(DataAnnotationText), Name = "GeneralDisplayPhoneNumber")]
        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; }
        public bool IsAnonymous { get; set; }
        public bool IsDelete { get; set; }

        public DateTime LastActivityDate { get; set; }
    }
}
