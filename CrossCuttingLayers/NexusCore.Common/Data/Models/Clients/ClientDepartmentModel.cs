using System;
using System.ComponentModel.DataAnnotations;
using NexusCore.Common.Resources;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Models.Clients
{
    public class ClientDepartmentModel : TrackableEntity
    {
        public Guid ClientId { get; set; }
        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "ClientDepartmentRequiredName")]
        [StringLength(500)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "ClientDepartmentRequiredContactTitle")]
        public string ContactTitle { get; set; }
        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "ClientDepartmentRequiredContactFirstName")]
        public string ContactFirstName { get; set; }
        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "ClientDepartmentRequiredContactLastName")]
        public string ContactLastName { get; set; }
        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "ClientDepartmentRequiredContactPhoneNumber")]
        public string ContactPhone { get; set; }
        public string ContactMobile { get; set; }
        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "ClientDepartmentRequiredContactEmail")]
        public string ContactEmail { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
    }
}
