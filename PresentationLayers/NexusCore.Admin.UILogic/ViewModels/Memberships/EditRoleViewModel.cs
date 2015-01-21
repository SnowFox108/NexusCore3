using System;
using NexusCore.Common.Data.Models.Memberships;
using NexusCore.Common.Services.MembershipServices;

namespace NexusCore.Admin.UILogic.ViewModels.Memberships
{
    public class EditRoleViewModel
    {
        public RoleModel Role { get; set; }

        public void InitData(IMembershipService membership, Guid roleId)
        {
            Role = membership.GetRole(roleId);
        }
    }
}
