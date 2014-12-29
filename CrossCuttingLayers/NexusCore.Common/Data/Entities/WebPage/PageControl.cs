using System;
using NexusCore.Common.Data.Enums;
using NexusCore.Common.Data.Models.Page;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Entities.WebPage
{
    public class PageControl: Entity
    {
        public Guid PageId { get; set; }
        public string GridParentPath { get; set; }
        public string GridTagName { get; set; }
        public PageGridType ItemType { get; set; }
        public Guid ControlId { get; set; }
        public string ControlSettings { get; set; }
        public int SortOrder { get; set; }

        public virtual WebPage Page { get; set; }
    }
}
