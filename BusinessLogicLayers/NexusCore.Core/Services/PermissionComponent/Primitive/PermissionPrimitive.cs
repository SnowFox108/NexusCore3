using System;
using System.Collections.Generic;
using System.Linq;
using NexusCore.Common.Data.Entities.Permission;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.SourceTrees;
using NexusCore.Common.Services.PermissionServices;
using NexusCore.Core.Services.Infrastructure;
using NexusCore.Infrasructure.Security;

namespace NexusCore.Core.Services.PermissionComponent.Primitive
{
    public class PermissionPrimitive : BasePrimitiveService, IPermissionPrimitive
    {

        private readonly IAuthenticationManager _authenticationManager;

        public PermissionPrimitive(IUnitOfWork unitOfWork, IAuthenticationManager authenticationManager) : base(unitOfWork)
        {
            _authenticationManager = authenticationManager;
        }

        public void AddRoleToPermission(Guid sourceTreeId, Guid roleId, bool permission = false)
        {
            AddEntryToPermission(sourceTreeId, roleId, permission, SourceTreePermissionType.ByRole);
        }

        public void AddUserToPermission(Guid sourceTreeId, Guid userId, bool permission = false)
        {
            AddEntryToPermission(sourceTreeId, userId, permission, SourceTreePermissionType.ByUser);
        }

        private void AddEntryToPermission(Guid sourceTreeId, Guid permitId, bool permission, SourceTreePermissionType permissionType)
        {
            UnitOfWork.Repository<SourceTreePermission>().Insert(new SourceTreePermission
            {
                SourceTreeId = sourceTreeId,
                CanView = permission,
                CanCreate = permission,
                CanModify = permission,
                CanRollback = permission,
                CanChangePermission = permission,
                CanApprove = permission,
                CanPublish = permission,
                CanEnterDesignMode = permission,
                PermissionType = permissionType,
                PermitId = permitId
            });
        }

        public void RemoveInheritPermission(Guid sourceTreeId)
        {
            var adminRole = _authenticationManager.GetRoleByName(DefaultUserRoles.Administrators);
            var guestRole = _authenticationManager.GetRoleByName(DefaultUserRoles.Guest);

            AddRoleToPermission(sourceTreeId, adminRole.Id, true);
            AddRoleToPermission(sourceTreeId, guestRole.Id);
        }

        public void InheritPermission(Guid sourceTreeId)
        {
            var permissions = GetPermissionEntries(sourceTreeId);
            foreach (var sourceTreePermission in permissions)
                UnitOfWork.Repository<SourceTreePermission>().Delete(sourceTreePermission);
        }

        public IEnumerable<SourceTreePermission> GetPermissionEntries(Guid sourceTreeId)
        {
            return UnitOfWork.Repository<SourceTreePermission>().Get(st => st.SourceTreeId == sourceTreeId);
        }

        public SourceTreePermission GetPermissionByRole(Guid sourceTreeId, Guid roleId)
        {
            return GetPermission(sourceTreeId, roleId, SourceTreePermissionType.ByRole);
        }

        public SourceTreePermission GetPermissionByUser(Guid sourceTreeId, Guid userId)
        {
            return GetPermission(sourceTreeId, userId, SourceTreePermissionType.ByUser);
        }

        private SourceTreePermission GetPermission(Guid sourceTreeId, Guid permitId, SourceTreePermissionType permissionType)
        {
            var permission =
                UnitOfWork.Repository<SourceTreePermission>()
                    .Get(st => st.SourceTreeId == sourceTreeId && st.PermitId == permitId)
                    .FirstOrDefault();
            if (permission == null)
                return new SourceTreePermission
                {
                    SourceTreeId = sourceTreeId,
                    CanView = false,
                    CanCreate = false,
                    CanModify = false,
                    CanRollback = false,
                    CanChangePermission = false,
                    CanApprove = false,
                    CanPublish = false,
                    CanEnterDesignMode = false,
                    PermissionType = permissionType,
                    PermitId = permitId
                };
            return permission;
        }
    }
}
