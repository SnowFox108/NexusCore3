using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexusCore.Common.Infrastructure;
using NexusCore.Common.Services;

namespace NexusCore.Admin.UILogic
{
    public class TestLogic
    {
        public TestLogic()
        {
            
        }

        public void CallService()
        {
            var service = EngineContext.Instance.DiContainer.GetInstance<IComponentServices>();

            service.MembershipService.ResetUserPassword("");
        }
    }
}
