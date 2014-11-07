using System.Reflection;
using NexusCore.Infrasructure.Attributes;
using NexusCore.Infrasructure.Models.Enums;

namespace NexusCore.Common.Adapter.ErrorHandlers
{
    public static class LogCodeAttributeExtensions
    {
        public static StoreInLogAttribute Value(this LogCode value)
        {
            var type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            var attributes =
                fieldInfo.GetCustomAttribute(typeof (StoreInLogAttribute), false) as StoreInLogAttribute;
            return attributes?? new StoreInLogAttribute();
        }
    }
}
