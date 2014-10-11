using System;
using NexusCore.Common.Data.Models.SourceTree;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Entities.SourceTree
{
    public class SourceTree : Entity
    {
        public Guid ParentId { get; set; }
        public string Name { get; set; }
        public SourceTreeItemType ItemType { get; set; }
        public Guid ItemId { get; set; }
        public int SortOrder { get; set; }

    }
}
