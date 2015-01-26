using NexusCore.Common.Resources;
using NexusCore.Infrasructure.Data;
using NexusCore.Infrasructure.Security;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace NexusCore.Common.Data.Models.Memberships
{
    [DataContract]
    public class RoleModel:Entity
    {
        [DataMember]
        [Required(ErrorMessageResourceType = typeof(DataAnnotationText), ErrorMessageResourceName = "MembershipRequiredRoleName")]
        [Display(ResourceType = typeof(DataAnnotationText), Name = "MembershipDisplayRoleName")]
        public string RoleName { get; set; }

        [DataMember]
        [Display(ResourceType = typeof(DataAnnotationText), Name = "GeneralDisplayDescription")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public bool IsSystemRole
        {
            get { return DefaultUserRoles.SystemUserRoles.Contains(RoleName); }
        }
    }
}
