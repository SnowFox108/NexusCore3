using System.Reflection;
using NexusCore.Common.Data.Enums;
using NexusCore.Infrasructure.Attributes;

namespace NexusCore.Common.Helper.Extensions
{
    public static class WebsiteSettingExtensions
    {
        public static SettingDataTypeAttribute Value(this WebsiteSettingType value)
        {
            var type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            var attributes =
                fieldInfo.GetCustomAttribute(typeof (SettingDataTypeAttribute), false) as SettingDataTypeAttribute;
            return attributes ?? new SettingDataTypeAttribute();
        }
    }
}
