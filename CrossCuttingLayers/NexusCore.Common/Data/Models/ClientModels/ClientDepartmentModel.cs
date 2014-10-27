using System;
using System.ComponentModel.DataAnnotations;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Models.ClientModels
{
    public class ClientDepartmentModel : TrackableEntity
    {
        public Guid ClientId { get; set; }
        [Required(ErrorMessage = "Please enter a department name")]
        [StringLength(500)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Please select a contact person title")]
        public string ContactTitle { get; set; }
        [Required(ErrorMessage = "Please enter a contact person firstname")]
        public string ContactFirstName { get; set; }
        [Required(ErrorMessage = "Please enter a contact person lastname")]
        public string ContactLastName { get; set; }
        [Required(ErrorMessage = "Please enter a contact person phone")]
        public string ContactPhone { get; set; }
        public string ContactMobile { get; set; }
        [Required(ErrorMessage = "Please enter a contact person email")]
        public string ContactEmail { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
    }
}
