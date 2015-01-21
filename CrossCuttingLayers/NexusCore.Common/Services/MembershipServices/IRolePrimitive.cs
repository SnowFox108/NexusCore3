using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Entities.Membership;
using NexusCore.Common.Data.Models.Memberships;

namespace NexusCore.Common.Services.MembershipServices
{
    public interface IRolePrimitive
    {
        int GetRoleCount(RoleSearchFilter searchFilter);
        IEnumerable<Role> GetRoles(RoleSearchFilter searchFilter);
        Role GetRole(Guid roleId);
        void UpdateRole(Role role);
        void DeleteRole(Role role);
    }
}
