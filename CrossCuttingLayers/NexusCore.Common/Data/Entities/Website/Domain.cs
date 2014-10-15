using System;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Entities.Website
{
    public class Domain : Entity
    {
        public Guid WebsiteId { get; set; }
        public Guid Name { get; set; }
        public bool IsActive { get; set; }

        public virtual WebSite WebSite { get; set; }
    }
}
