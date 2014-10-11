using System.Linq;
using NexusCore.Common.Data.Models.SourceTree;
using NexusCore.Common.Data.Values.SourceTree;

namespace NexusCore.Common.Data.Infrastructure.Extensions
{
    public static class SourceTreeExtensions
    {
        public static SourceTreeItemTypeModel Value(this SourceTreeItemType item)
        {
            return SourceTreeItemTypeValues.Instance.Values.Single(s => s.ItemType == item);
        }
    }



}
