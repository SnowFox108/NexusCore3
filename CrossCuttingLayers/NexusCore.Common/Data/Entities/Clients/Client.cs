using System;
using System.Collections.Generic;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Entities.Clients
{
    public class Client : Entity, ITrackable
    {
        public string FriendlyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }
        public Guid PrimaryDepartmentId { get; set; }

        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }

        public IEnumerable<ClientDepartment> ClientDepartments { get; set; }
    }
}
