using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Entities.Permission;

namespace NexusCore.Common.Services.PermissionServices
{
    public interface IPermissionPrimitive
    {
        void AddRoleToPermission(Guid sourceTreeId, Guid roleId, bool permission = false);
        void AddUserToPermission(Guid sourceTreeId, Guid userId, bool permission = false);
        void RemoveInheritPermission(Guid sourceTreeId);
        void InheritPermission(Guid sourceTreeId);
        IEnumerable<SourceTreePermission> GetPermissionEntries(Guid sourceTreeId);
        SourceTreePermission GetPermissionByRole(Guid sourceTreeId, Guid roleId);
        SourceTreePermission GetPermissionByUser(Guid sourceTreeId, Guid userId);
    }
}
