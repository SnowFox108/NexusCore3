
using System.Collections.Generic;
using NexusCore.Common.Data.Enums;

namespace NexusCore.Common.Data.Models.Page
{
    public class PageGridTypeModel
    {
        public PageGridType ItemType { get; set; }
        public string TagName { get; set; }
        public string ClassName { get; set; }
        public string OptionalClassName { get; set; }
        public string Style { get; set; }
        public bool IsShowOnMenu { get; set; }
        public IEnumerable<PageGridType> Constrains { get; set; }
    }
}
