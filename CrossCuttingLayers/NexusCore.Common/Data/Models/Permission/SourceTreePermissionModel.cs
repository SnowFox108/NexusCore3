using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusCore.Common.Data.Models.Permission
{
    public class SourceTreePermissionModel
    {
        public Guid SourceTreeId { get; set; }
        public bool CanView { get; set; }
        public bool CanCreate { get; set; }
        public bool CanModify { get; set; }
        public bool CanRollback { get; set; }
        public bool CanChangePermission { get; set; }
        public bool CanApprove { get; set; }
        public bool CanPublish { get; set; }
        public bool CanEnterDesignMode { get; set; }
    }
}
