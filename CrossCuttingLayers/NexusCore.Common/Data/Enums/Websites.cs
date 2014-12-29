using NexusCore.Infrasructure.Attributes;
using NexusCore.Infrasructure.Models.Enums;

namespace NexusCore.Common.Data.Enums
{
    public enum WebsiteSettingType
    {
        // User Login
        [SettingDataType(WebsiteSettingDataType.Id)]
        MailTemplateRegister = 1,

        // Pages
        [SettingDataType(WebsiteSettingDataType.Id)]
        PageError404 = 10
    }
}
