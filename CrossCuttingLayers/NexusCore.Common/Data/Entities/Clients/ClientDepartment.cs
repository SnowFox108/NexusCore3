using System;
using System.ComponentModel.DataAnnotations;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Entities.Clients
{
    public class ClientDepartment : TrackableEntity
    {
        public Guid ClientId { get; set; }
        [StringLength(500)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactTitle { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMobile { get; set; }
        public string ContactEmail { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }

        public virtual Client Client { get; set; }
    }
}
