using System.Collections.Generic;

namespace NexusCore.Common.Data.Models.SourceTrees
{
    public class SourceTreeItemTypeModel
    {
        public SourceTreeItemType ItemType { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public bool IsRoot { get; set; }
        public bool IsSignleItemLinked { get; set; }
        public IEnumerable<SourceTreeItemType> Constraints { get; set; }
    }
}
