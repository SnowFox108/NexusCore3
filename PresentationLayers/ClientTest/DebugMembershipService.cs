using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexusCore.Common.Infrastructure;
using NexusCore.Common.Services.InstallationServices;
using NexusCore.Common.Services.MembershipServices;

namespace ClientTest
{
    public class DebugMembershipService
    {
        public DebugMembershipService()
        {
            var service = EngineContext.Instance.DiContainer.GetInstance<IMembershipService>();
            service.ResetUserPassword("");
            Console.WriteLine(service.ToString());
        }
    }
}
