using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using NexusCore.Common.Adapter.ErrorHandlers;
using NexusCore.Common.Adapter.Language;
using NexusCore.Common.Resources;
using NexusCore.Infrasructure.Models.Enums;

namespace ClientTest
{
    public class GetLogCodeAttributes
    {
        public GetLogCodeAttributes()
        {
            const LogCode myEnum = LogCode.CriticalUncategoriedError;

            var result = myEnum.Value();

            Console.WriteLine("IsLogged: {0} \t Category: {1} \t Level: {2}", result.IsLogged, result.Category,
                result.Level);

            ErrorAdapter.ModelState.AddModelError("", "Something is wrong", logCode: LogCode.CriticalInstallationRepeated);

            Console.WriteLine(LogCodeText.GetString(LogCode.CriticalInstallationRepeated));
        }
    }
}
