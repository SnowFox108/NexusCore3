using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Entities.Website;
using NexusCore.Common.Data.Enums;

namespace NexusCore.Common.Services.WebsiteServices
{
    public interface IWebsiteSettingPrimitive
    {
        void Create(WebsiteSetting setting);
        WebsiteSetting GetSetting(Guid websiteId, WebsiteSettingType settingType);
        Guid GetSettingId(Guid websiteId, WebsiteSettingType settingType, bool isConstrain = true);
        string GetSettingValue(Guid websiteId, WebsiteSettingType settingType);
        IEnumerable<WebsiteSetting> GetSettings(Guid websiteId);
        void Update(WebsiteSetting setting);

    }
}
