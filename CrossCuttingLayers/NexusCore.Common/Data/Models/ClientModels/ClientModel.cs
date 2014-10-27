using System.ComponentModel.DataAnnotations;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Models.ClientModels
{
    public class ClientModel : TrackableEntity
    {
        public string FriendlyId { get; set; }
        [Required(ErrorMessage = "Please enter a client name")]
        [StringLength(500)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }
    }
}
