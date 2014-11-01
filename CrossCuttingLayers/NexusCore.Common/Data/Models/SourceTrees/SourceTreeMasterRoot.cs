using System;
using NexusCore.Common.Data.Entities.SourceTrees;

namespace NexusCore.Common.Data.Models.SourceTrees
{
    public static class SourceTreeRoot
    {
        public static SourceTree MasterNode { get; private set;}

        static SourceTreeRoot()
        {
            MasterNode = new SourceTree()
            {
                Id = new Guid("0C8CFB8B-85E2-44BA-9CEA-37B3DC536575"),
                ParentId = new Guid(),
                Name = "Master Root",
                ItemType = SourceTreeItemType.MasterRoot,
                SortOrder = 0
            };
        }
    }
}
