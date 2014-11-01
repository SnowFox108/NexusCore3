using System;
using NexusCore.Common.Data.Models.SourceTrees;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Entities.SourceTrees
{
    public class ItemInSourceTree : Entity
    {
        public SourceTreeItemModuleType ModuleType { get; set; }
        public Guid SourceTreeId { get; set; }
        public Guid ItemId { get; set; }

        public SourceTree SourceTree { get; set; }
    }
}
