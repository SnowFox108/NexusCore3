using System.Globalization;
using NexusCore.Common.Resources;
using NexusCore.Infrasructure.Models.Enums;

namespace NexusCore.Common.Adapter.Language
{
    public class LogCodeText
    {
        public static string GetString(LogCode code)
        {
           return LogCodeRes.ResourceManager.GetString(string.Format("C{0}", (int)code), CultureInfo.CurrentCulture);            
        }
    }
}
