using System;
using NexusCore.Common.Data.Enums;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Entities.Website
{
    public class WebsiteSetting : Entity
    {
        public Guid WebSiteId { get; set; }
        public WebsiteSettingType SettingType { get; set; }
        public Guid ItemId { get; set; }
        public string Value { get; set; }

        public virtual Website WebSite { get; set; }
    }
}
