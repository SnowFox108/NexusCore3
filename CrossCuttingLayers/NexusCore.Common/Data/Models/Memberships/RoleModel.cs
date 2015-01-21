using System.ComponentModel.DataAnnotations;
using NexusCore.Common.Resources;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Models.Memberships
{
    public class RoleModel:Entity
    {
        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "MembershipRequiredRoleName")]
        [Display(ResourceType = typeof(DataAnnotationText), Name = "MembershipDisplayRoleName")]
        public string RoleName { get; set; }

        [Display(ResourceType = typeof(DataAnnotationText), Name = "GeneralDisplayDescription")]
        public string Description { get; set; }
    }
}
