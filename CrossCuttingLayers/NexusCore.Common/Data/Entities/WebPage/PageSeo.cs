using System;
using System.ComponentModel.DataAnnotations;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Entities.WebPage
{
    public class PageSeo :Entity
    {
        public Guid MenuItemId { get; set; }
        [StringLength(500)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
    }
}
