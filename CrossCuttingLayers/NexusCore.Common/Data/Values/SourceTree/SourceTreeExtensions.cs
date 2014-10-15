using System.Linq;
using NexusCore.Common.Data.Models.SourceTree;

namespace NexusCore.Common.Data.Values.SourceTree
{
    public static class SourceTreeExtensions
    {
        public static SourceTreeItemTypeModel Value(this SourceTreeItemType item)
        {
            return SourceTreeItemTypeValues.Instance.Values.Single(s => s.ItemType == item);
        }
    }



}
