using System;
using System.ComponentModel.DataAnnotations;
using NexusCore.Common.Resources;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Models.Websites
{
    public class WebsiteModel: TrackableEntity
    {
        public Guid ClientId { get; set; }
        public string FriendlyId { get; set; }
        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "WebsiteRequiredName")]
        [StringLength(500, ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "GeneralMaximum500")]
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ActivedDomainId { get; set; }
        public Guid CurrentHomeMenuId { get; set; }
        public string RootUrl { get; set; }
        public string FavIconUrl { get; set; }
        public string PageTitlePrefix { get; set; }
        public string PageTitleSuffix { get; set; }
        public bool IsActive { get; set; }
        public bool IsUnderMaintenance { get; set; }

    }
}
