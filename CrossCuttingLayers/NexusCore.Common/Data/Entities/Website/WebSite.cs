using System;
using System.Collections.Generic;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Entities.Website
{
    public class Website : TrackableEntity
    {
        public string FriendlyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ActivedDomainId { get; set; }
        public Guid CurrentHomeMenuId { get; set; }
        public string RootUrl { get; set; }
        public string FavIconUrl { get; set; }
        public string PageTitlePrefix { get; set; }
        public string PageTitleSuffix { get; set; }
        public bool IsActive { get; set; }

        public virtual IEnumerable<Domain> Domains { get; set; }
    }
}
