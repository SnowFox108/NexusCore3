using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Entities.Membership;
using NexusCore.Common.Data.Models.Memberships;
using NexusCore.Infrasructure.Model.Enums;

namespace NexusCore.Common.Services.MembershipServices
{
    public interface IUserPrimitive
    {
        int GetUserCount(UserSearchFilter searchFilter);
        IEnumerable<User> GetUsers(UserSearchFilter searchFilter);
        IEnumerable<User> GetUsers(string sortOrder = "FirstName", SortDirection sortDirection = SortDirection.Asc, int pageNumber = 1, int pageSize = 10);
        User GetUser(Guid userId);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }    
}
