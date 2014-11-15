
using System;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Infrasructure.Security.Models
{
    public interface IUser : IEntity, ITrackable
    {
        string UserName { get; set; }
        string Email { get; set; }
        string PasswordHash { get; set; }
        string PasswordSalt { get; set; }

        string Title { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }

        bool IsActive { get; set; }
        bool IsAnonymous { get; set; }

        DateTime LastActivityDate { get; set; }

    }
}
