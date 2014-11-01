using System;

namespace NexusCore.Common.Data.Models.SourceTrees
{
    public class SourceTreeModel
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public string Name { get; set; }
        public SourceTreeItemType ItemType { get; set; }
    }
}
