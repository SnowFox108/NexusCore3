
using System.Collections.Generic;
using NexusCore.Infrasructure.Security.Models;

namespace NexusCore.Infrasructure.Security
{
    public interface ICurrentUserProvider
    {
        string Email { get; }
        ICurrentUserModel User { get; }
        IEnumerable<IRole> Roles { get; }
        bool IsAdmin { get; }
    }
}
