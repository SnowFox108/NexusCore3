using System;
using NexusCore.Common.Data.Models.Memberships;
using NexusCore.Infrasructure.Security;

namespace NexusCore.Common.Services.MembershipServices
{
    public interface IMembershipService
    {
        // Users
        void DeleteUser(UserModel user);
        UserManagerModel GetUsers(UserSearchFilter searchFilter);
        UserModel GetUser(Guid userId);
        void RegisterNewUser(Guid websiteId, string title, string userName, string email, string firstName, string lastName,
            string phoneNumber);
        void SetupPassword(IActivationToken token, string password);
        void ResetUserPassword(string email);        
        void UpdateUser(UserModel user);

        // Roles
        void CreateRole(RoleModel role);
        void DeleteRole(Guid roleId);
        RoleManagerModel GetRoles(RoleSearchFilter searchFilter);
        RoleModel GetRole(Guid roleId);
        void UpdateRole(RoleModel role);
    }
}
