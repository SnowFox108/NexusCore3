using System.Linq;
using NexusCore.Common.Data.Enums;
using NexusCore.Common.Data.Models.Page;

namespace NexusCore.Common.Data.Values.Page
{
    public static class PageGridExtensions
    {
        public static PageGridTypeModel Value(this PageGridType item)
        {
            return PageGridTypeValues.Instance.Values.Single(s => s.ItemType == item);
        }

    }
}
