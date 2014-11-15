using System;
using NexusCore.Common.Data.Models.Permission;

namespace NexusCore.Common.Services.PermissionServices
{
    public interface IPermissionAggregate
    {
        bool CanView(Guid sourceTreeId);
        bool CanCreate(Guid sourceTreeId);
        bool CanModify(Guid sourceTreeId);
        bool CanRollback(Guid sourceTreeId);
        bool CanChangePermission(Guid sourceTreeId);
        bool CanApprove(Guid sourceTreeId);
        bool CanPublish(Guid sourceTreeId);
        bool CanEnterDesignMode(Guid sourceTreeId);

        SourceTreePermissionModel GetInheritedPermission(Guid sourceTreeId);
    }
}
