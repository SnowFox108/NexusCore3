using System;

namespace NexusCore.Infrasructure.Security.Models
{
    public interface ICurrentUserModel
    {
        Guid Id { get; set; }
        string Email { get; set; }
        string DisplayName { get; }
        string Title { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime LastActivityDate { get; set; }

    }
}
