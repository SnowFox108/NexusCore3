using System;
using System.ComponentModel.DataAnnotations;
using NexusCore.Common.Data.Models.Infrastructure;
using NexusCore.Common.Resources;

namespace NexusCore.Common.Data.Models.Websites
{
    public class WebsiteModel: TrackableModel
    {
        [Display(ResourceType = typeof(DataAnnotationText), Name = "WebsiteDisplayFriendlyId")]
        public string FriendlyId { get; set; }

        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "WebsiteRequiredName")]
        [StringLength(500, ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "GeneralMaximum500")]
        [Display(ResourceType = typeof(DataAnnotationText), Name = "WebsiteDisplayName")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(DataAnnotationText), Name = "WebsiteDisplayDescription")]
        public string Description { get; set; }

        public Guid ActivedDomainId { get; set; }
        public Guid CurrentHomeMenuId { get; set; }

        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "WebsiteRequiredRootUrl")]
        [Display(ResourceType = typeof(DataAnnotationText), Name = "WebsiteDisplayRootUrl")]
        public string RootUrl { get; set; }

        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "WebsiteRequiredFavIconUrl")]
        [Display(ResourceType = typeof(DataAnnotationText), Name = "WebsiteDisplayFavIconUrl")]
        public string FavIconUrl { get; set; }

        [Display(ResourceType = typeof(DataAnnotationText), Name = "WebsiteDisplayPageTitlePrefix")]
        public string PageTitlePrefix { get; set; }

        [Display(ResourceType = typeof(DataAnnotationText), Name = "WebsiteDisplayPageTitleSuffix")]
        public string PageTitleSuffix { get; set; }

        [Display(ResourceType = typeof(DataAnnotationText), Name = "WebsiteDisplayIsActive")]
        public bool IsActive { get; set; }

        public bool IsUnderMaintenance { get; set; }

    }
}
