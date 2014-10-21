using System.Threading;
using NexusCore.Infrasructure.Security;

namespace NexusCore.Common.Security
{
    public class CurrentUserProvider: ICurrentUserProvider
    {
        public string Email
        {
            get { return Thread.CurrentPrincipal.Identity.Name; }
        }
    }
}
