
using System.Collections.Generic;

namespace NexusCore.Common.Data.Models.SourceTree
{
    public class SourceTreeItemTypeModel
    {
        public SourceTreeItemType ItemType { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public bool IsRoot { get; set; }
        public IEnumerable<SourceTreeItemType> Constraints { get; set; }
    }
}
