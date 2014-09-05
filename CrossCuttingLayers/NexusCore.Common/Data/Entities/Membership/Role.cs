using System.Collections.Generic;
using NexusCore.Infrasructure.Data;
using NexusCore.Infrasructure.Security.Models;

namespace NexusCore.Common.Data.Entities.Membership
{
    public class Role : Entity, IRole
    {
        public string RoleName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }

    }
}
