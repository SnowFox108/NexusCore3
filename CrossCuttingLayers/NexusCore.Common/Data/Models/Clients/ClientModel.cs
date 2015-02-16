using System.ComponentModel.DataAnnotations;
using NexusCore.Common.Data.Models.Infrastructure;
using NexusCore.Common.Resources;

namespace NexusCore.Common.Data.Models.Clients
{
    public class ClientModel : TrackableModel
    {
        public string FriendlyId { get; set; }
        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "ClientRequiredName")]
        [StringLength(500, ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "GeneralMaximum500")]
        [Display(ResourceType = typeof(DataAnnotationText), Name= "ClientDisplayName")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(ResourceType = typeof(DataAnnotationText), Name = "GeneralDisplayDescription")]
        public string Description { get; set; }

        [Display(ResourceType = typeof(DataAnnotationText), Name = "ClientDisplayLogoUrl")]
        public string LogoUrl { get; set; }
    }
}
