using System;
using System.Collections.Generic;
using NexusCore.Infrasructure.Data;
using NexusCore.Infrasructure.Security.Models;

namespace NexusCore.Common.Data.Entities.Membership
{
    public class User : Entity, IUser, ITrackable
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; }
        public bool IsAnonymous { get; set; }

        public DateTime LastActivityDate { get; set; }
        
        // Trackable item
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<UserExternalLogin> UserExternalLogins { get; set; }
    }
}
