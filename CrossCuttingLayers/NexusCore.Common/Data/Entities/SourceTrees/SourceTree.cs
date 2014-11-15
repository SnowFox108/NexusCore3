using System.Collections.Generic;
using NexusCore.Common.Data.Entities.Permission;
using NexusCore.Common.Data.Models.SourceTrees;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Entities.SourceTrees
{
    public class SourceTree : Entity
    {
        //public Guid ParentId { get; set; }
        public string Name { get; set; }
        public SourceTreeItemType ItemType { get; set; }
        public int SortOrder { get; set; }
        public bool IsPrivacyInherited { get; set; }

        public virtual SourceTree Parent { get; set; }
        public virtual ICollection<SourceTree> ChildNodes { get; set; }
        public virtual IEnumerable<ItemInSourceTree> ItemsInSourceTrees { get; set; }
        public virtual IEnumerable<SourceTreePermission> SourceTreePermissions { get; set; }
    }
}
