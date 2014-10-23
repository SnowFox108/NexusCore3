using System;

namespace NexusCore.Common.Data.Models.SourceTree
{
    public static class SourceTreeRoot
    {
        public static Entities.SourceTree.SourceTree MasterNode { get; private set;}

        static SourceTreeRoot()
        {
            MasterNode = new Entities.SourceTree.SourceTree()
            {
                Id = new Guid("0C8CFB8B-85E2-44BA-9CEA-37B3DC536575"),
                ParentId = new Guid(),
                Name = "Master Root",
                ItemType = SourceTreeItemType.MasterRoot,
                ItemId = new Guid(),
                SortOrder = 0
            };
        }
    }
}
