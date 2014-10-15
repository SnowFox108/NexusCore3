using System;
using System.ComponentModel.DataAnnotations;
using NexusCore.Common.Data.Models.Page;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Entities.WebPage
{
    public class PageLink : Entity
    {
        [StringLength(300)]
        public string Name { get; set; }
        public PageLinkType LinkType { get; set; }
        public string Url { get; set; }
        public string Target { get; set; }
        public Guid PointerId { get; set; }
    }
}
