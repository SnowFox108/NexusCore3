using System.ComponentModel.DataAnnotations;
using NexusCore.Common.Resources;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Models.Clients
{
    public class ClientModel : TrackableEntity
    {
        public string FriendlyId { get; set; }
        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "ClientRequiredName")]
        [StringLength(500, ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "GeneralMaximum500")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }
    }
}
