using System;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Entities.Membership
{
    public class UserExternalLogin : Entity
    {
        public Guid UserId { get; set; }
        public string ExternalUserName { get; set; }
        public string ProviderName { get; set; }

        public virtual User User { get; set; }
    }
}
