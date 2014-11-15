using System;
using NexusCore.Infrasructure.Security.Models;

namespace NexusCore.Common.Data.Models.Memberships
{
    public class CurrentUserModel : ICurrentUserModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }

        public string DisplayName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime LastActivityDate { get; set; }
    }
}
