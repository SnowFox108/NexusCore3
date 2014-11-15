using System;
using NexusCore.Common.Adapter.ErrorHandlers;
using NexusCore.Common.Data.Entities.Permission;
using NexusCore.Common.Data.Entities.SourceTrees;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.Permission;
using NexusCore.Common.Infrastructure;
using NexusCore.Common.Services;
using NexusCore.Common.Services.PermissionServices;
using NexusCore.Core.Services.Infrastructure;
using NexusCore.Infrasructure.Models.Enums;
using NexusCore.Infrasructure.Security;

namespace NexusCore.Core.Services.PermissionComponent.Aggregate
{
    public class PermissionAggregate:BaseAggregateService, IPermissionAggregate
    {
        private readonly IAuthenticationManager _authenticationManager;

        public PermissionAggregate(IUnitOfWork unitOfWork, IPrimitiveServices primitiveServices, IAuthenticationManager authenticationManager) : base(unitOfWork, primitiveServices)
        {
            _authenticationManager = authenticationManager;
        }

        /// <summary>
        /// Suitable for single check, if you need check 2 permission please use GetInheritedPermission(Guid sourceTreeId)
        /// </summary>
        /// <param name="sourceTreeId">Guid</param>
        /// <returns>bool</returns>
        public bool CanView(Guid sourceTreeId)
        {
            return GetInheritedPermission(sourceTreeId).CanView;
        }

        /// <summary>
        /// Suitable for single check, if you need check 2 permission please use GetInheritedPermission(Guid sourceTreeId)
        /// </summary>
        /// <param name="sourceTreeId">Guid</param>
        /// <returns>bool</returns>
        public bool CanCreate(Guid sourceTreeId)
        {
            return GetInheritedPermission(sourceTreeId).CanCreate;
        }

        /// <summary>
        /// Suitable for single check, if you need check 2 permission please use GetInheritedPermission(Guid sourceTreeId)
        /// </summary>
        /// <param name="sourceTreeId">Guid</param>
        /// <returns>bool</returns>
        public bool CanModify(Guid sourceTreeId)
        {
            return GetInheritedPermission(sourceTreeId).CanModify;
        }

        /// <summary>
        /// Suitable for single check, if you need check 2 permission please use GetInheritedPermission(Guid sourceTreeId)
        /// </summary>
        /// <param name="sourceTreeId">Guid</param>
        /// <returns>bool</returns>
        public bool CanRollback(Guid sourceTreeId)
        {
            return GetInheritedPermission(sourceTreeId).CanRollback;
        }

        /// <summary>
        /// Suitable for single check, if you need check 2 permission please use GetInheritedPermission(Guid sourceTreeId)
        /// </summary>
        /// <param name="sourceTreeId">Guid</param>
        /// <returns>bool</returns>
        public bool CanChangePermission(Guid sourceTreeId)
        {
            return GetInheritedPermission(sourceTreeId).CanChangePermission;
        }

        /// <summary>
        /// Suitable for single check, if you need check 2 permission please use GetInheritedPermission(Guid sourceTreeId)
        /// </summary>
        /// <param name="sourceTreeId">Guid</param>
        /// <returns>bool</returns>
        public bool CanApprove(Guid sourceTreeId)
        {
            return GetInheritedPermission(sourceTreeId).CanApprove;
        }

        /// <summary>
        /// Suitable for single check, if you need check 2 permission please use GetInheritedPermission(Guid sourceTreeId)
        /// </summary>
        /// <param name="sourceTreeId">Guid</param>
        /// <returns>bool</returns>
        public bool CanPublish(Guid sourceTreeId)
        {
            return GetInheritedPermission(sourceTreeId).CanPublish;
        }

        /// <summary>
        /// Suitable for single check, if you need check 2 permission please use GetInheritedPermission(Guid sourceTreeId)
        /// </summary>
        /// <param name="sourceTreeId">Guid</param>
        /// <returns>bool</returns>
        public bool CanEnterDesignMode(Guid sourceTreeId)
        {
            return GetInheritedPermission(sourceTreeId).CanEnterDesignMode;
        }

        public SourceTreePermissionModel GetInheritedPermission(Guid sourceTreeId)
        {
            var roles = EngineContext.Instance.CurrentUser.Roles;
            var rootSourceTree = GetParentSourceTree(PrimitiveServices.SourceTreePrimitive.GetSourceTree(sourceTreeId));

            var result = new SourceTreePermissionModel
            {
                SourceTreeId = sourceTreeId,
                CanView = false,
                CanCreate = false,
                CanModify = false,
                CanRollback = false,
                CanChangePermission = false,
                CanApprove = false,
                CanPublish = false,
                CanEnterDesignMode = false
            };

            ApplyPermissions(result,
                PrimitiveServices.PermissionPrimitive.GetPermissionByUser(rootSourceTree.Id, EngineContext.Instance.CurrentUser.User.Id));

            foreach (var role in roles)
                ApplyPermissions(result,
                    PrimitiveServices.PermissionPrimitive.GetPermissionByRole(rootSourceTree.Id, role.Id));

            return result;
        }

        private SourceTree GetParentSourceTree(SourceTree sourceTree)
        {
            if (sourceTree.IsPrivacyInherited)
                if (sourceTree.Parent == null)
                    return sourceTree;
                else
                    return GetParentSourceTree(sourceTree.Parent);
            else
                return sourceTree;
        }

        private void ApplyPermissions(SourceTreePermissionModel currentPermision,
            SourceTreePermission applyingPermission)
        {
            currentPermision.CanView = applyingPermission.CanView || currentPermision.CanView;
            currentPermision.CanCreate = applyingPermission.CanCreate || currentPermision.CanCreate;
            currentPermision.CanModify = applyingPermission.CanModify || currentPermision.CanModify;
            currentPermision.CanRollback = applyingPermission.CanRollback || currentPermision.CanRollback;
            currentPermision.CanChangePermission = applyingPermission.CanChangePermission ||
                                                   currentPermision.CanChangePermission;
            currentPermision.CanApprove = applyingPermission.CanApprove || currentPermision.CanApprove;
            currentPermision.CanPublish = applyingPermission.CanPublish || currentPermision.CanPublish;
            currentPermision.CanEnterDesignMode = applyingPermission.CanEnterDesignMode ||
                                                  currentPermision.CanEnterDesignMode;
        }
    }
}
