using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NexusCore.Common.Helper
{
    public class TextMessage
    {
        private const string RegExString = @"\{\%\=\s*(?<TokenName>\w*)\s*\%\}";

        public static string ReplaceTokens(string templateText, IDictionary<string, string> tokenValues)
        {
            var regExToken = new Regex(RegExString, RegexOptions.IgnoreCase);
            var output = regExToken.Replace(templateText, (match) =>
            {
                var tokenName = match.Groups["TokenName"].Value.ToLower();
                try
                {
                    KeyValuePair<string, string> property = tokenValues.First(x => x.Key.ToLower() == tokenName);
                    return property.Value;
                }
                catch (Exception)
                {
                    throw new ArgumentException("No value supplied for token: " + tokenName);
                }
            });

            return output;
        }


    }
}
