using System;
using System.ComponentModel.DataAnnotations;
using NexusCore.Common.Data.Models.Infrastructure;
using NexusCore.Common.Resources;

namespace NexusCore.Common.Data.Models.Clients
{
    public class ClientDepartmentModel : TrackableModel
    {
        public Guid ClientId { get; set; }
        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "ClientDepartmentRequiredName")]
        [StringLength(500)]
        [Display(ResourceType = typeof(DataAnnotationText), Name = "ClientDepartmentDisplayName")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(DataAnnotationText), Name = "GeneralDisplayDescription")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "ClientDepartmentRequiredContactTitle")]
        [Display(ResourceType = typeof(DataAnnotationText), Name = "GeneralDisplayTitle")]
        public string ContactTitle { get; set; }

        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "ClientDepartmentRequiredContactFirstName")]
        [Display(ResourceType = typeof(DataAnnotationText), Name = "GeneralDisplayFirstName")]
        public string ContactFirstName { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "ClientDepartmentRequiredContactLastName")]
        [Display(ResourceType = typeof(DataAnnotationText), Name = "GeneralDisplayLastName")]
        public string ContactLastName { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "ClientDepartmentRequiredContactPhoneNumber")]
        [Display(ResourceType = typeof(DataAnnotationText), Name = "GeneralDisplayPhoneNumber")]
        public string ContactPhone { get; set; }

        [Display(ResourceType = typeof(DataAnnotationText), Name = "GeneralDisplayMobile")]
        public string ContactMobile { get; set; }

        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "ClientDepartmentRequiredContactEmail")]
        [Display(ResourceType = typeof(DataAnnotationText), Name = "GeneralDisplayEmail")]
        public string ContactEmail { get; set; }

        [Display(ResourceType = typeof(DataAnnotationText), Name = "GeneralDisplayAddress1")]
        public string AddressLine1 { get; set; }

        [Display(ResourceType = typeof(DataAnnotationText), Name = "GeneralDisplayAddress2")]
        public string AddressLine2 { get; set; }

        [Display(ResourceType = typeof(DataAnnotationText), Name = "GeneralDisplayTown")]
        public string Town { get; set; }

        [Display(ResourceType = typeof(DataAnnotationText), Name = "GeneralDisplayCounty")]
        public string County { get; set; }

        [Display(ResourceType = typeof(DataAnnotationText), Name = "GeneralDisplayCountry")]
        public string Country { get; set; }

        [Display(ResourceType = typeof(DataAnnotationText), Name = "GeneralDisplayPostCode")]
        public string PostCode { get; set; }
    }
}
