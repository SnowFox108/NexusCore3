using System;
using System.Text.RegularExpressions;

namespace NexusCore.Common.Helper
{
    public class Seo
    {
        public static string GetFriendlyName(string name)
        {
            return RemoveIllegalCharacter(name.ToLower()).Replace(' ', '-').Replace("--", "-");
        }

        private static string RemoveIllegalCharacter(string text)
        {
            try {
                return Regex.Replace(text, @"[^\w\s]", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
            } catch(RegexMatchTimeoutException){
                return string.Empty;
            }
        }
    }
}
