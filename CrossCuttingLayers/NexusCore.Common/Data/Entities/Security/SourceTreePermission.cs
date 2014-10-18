using System;
using NexusCore.Common.Data.Models.SourceTree;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Entities.Security
{
    public class SourceTreePermission : Entity
    {
        public bool CanView { get; set; }
        public bool CanCreate { get; set; }
        public bool CanModify { get; set; }
        public bool CanRollback { get; set; }
        public bool CanChangePermission { get; set; }
        public bool CanApprove { get; set; }
        public bool CanPublish { get; set; }
        public bool CanEnterDesignMode { get; set; }
        public SourceTreePermissionType PermissionType { get; set; }
        public Guid PermitId { get; set; }
    }
}
