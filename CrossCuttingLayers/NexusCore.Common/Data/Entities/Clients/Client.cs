using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Entities.Clients
{
    public class Client : TrackableEntity
    {
        public string FriendlyId { get; set; }
        [StringLength(500)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }
        public bool IsActive { get; set; }
        public Guid PrimaryDepartmentId { get; set; }

        public IEnumerable<ClientDepartment> ClientDepartments { get; set; }
    }
}
