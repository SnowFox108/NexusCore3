using System;
using System.Collections.Generic;
using System.Linq;
using NexusCore.Common.Adapter.ErrorHandlers;
using NexusCore.Common.Data.Entities.Website;
using NexusCore.Common.Data.Enums;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Helper.Extensions;
using NexusCore.Common.Services.WebsiteServices;
using NexusCore.Core.Services.Infrastructure;
using NexusCore.Infrasructure.Models.Enums;

namespace NexusCore.Core.Services.WebsiteComponent.Primitive
{
    public class WebsiteSettingPrimitive : BasePrimitiveService, IWebsiteSettingPrimitive
    {
        public WebsiteSettingPrimitive(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void Create(WebsiteSetting setting)
        {
            if (GetSetting(setting.WebSiteId, setting.SettingType) != null)
            {
                ErrorAdapter.ModelState.AddModelError(logCode: LogCode.CriticalWebsiteSettingRepeated);
                return;
            }

            UnitOfWork.Repository<WebsiteSetting>().Insert(setting);
        }

        public WebsiteSetting GetSetting(Guid websiteId, WebsiteSettingType settingType)
        {
            return
                UnitOfWork.Repository<WebsiteSetting>()
                    .Get(s => s.WebSiteId == websiteId && s.SettingType == settingType)
                    .FirstOrDefault();
        }

        public Guid GetSettingId(Guid websiteId, WebsiteSettingType settingType)
        {
            var setting = GetSetting(websiteId, settingType);
            if (setting != null && setting.SettingType.Value().DataType == WebsiteSettingDataType.Id)
                return setting.ItemId;
            else
            {
                ErrorAdapter.ModelState.AddModelError(logCode: LogCode.CriticalWebsiteSettingCannotReadValue);
                return new Guid();
            }
        }

        public string GetSettingValue(Guid websiteId, WebsiteSettingType settingType)
        {
            var setting = GetSetting(websiteId, settingType);
            if (setting != null && setting.SettingType.Value().DataType == WebsiteSettingDataType.Value)
                return setting.Value;
            else
            {
                var error = ErrorAdapter.ModelState.AddModelError(logCode: LogCode.CriticalWebsiteSettingCannotReadValue);
                throw new Exception(error.ErrorMessage);
            }
        }

        public IEnumerable<WebsiteSetting> GetSettings(Guid websiteId)
        {
            return UnitOfWork.Repository<WebsiteSetting>().Get(s => s.WebSiteId == websiteId);
        }

        public void Update(WebsiteSetting setting)
        {
            UnitOfWork.Repository<WebsiteSetting>().Update(setting);
        }
    }
}
