using System;
using System.Collections.Generic;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Entities.Website
{
    public class WebSite : Entity , ITrackable
    {
        public string Name { get; set; }
        public Guid ActivedDomainId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }

        public virtual IEnumerable<Domain> Domains { get; set; }
    }
}
