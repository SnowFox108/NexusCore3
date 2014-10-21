using System;
using System.Collections.Generic;
using NexusCore.Infrasructure.Security.Models;

namespace NexusCore.Infrasructure.Security
{
    public interface IAuthenticationManager
    {
        /// <summary>
        /// Create a new user in system
        /// </summary>
        /// <param name="title"></param>
        /// <param name="userName"></param>
        /// <param name="email"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        IActivationToken CreateUser(string title, string userName, string email, string firstName, string lastName,
            string phoneNumber);

        /// <summary>
        /// Updates existing user basic information
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="title"></param>
        /// <param name="userName"></param>
        /// <param name="email"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        int UpdateUser(Guid userId, string title, string userName, string email, string firstName, string lastName,
            string phoneNumber);

        bool Authenticate(string userEmail, string password);
        IUser LoginAuthenticate(string userEmail, string password);
        IUser GetUser(Guid userId);
        IUser GetUserByEmail(string email);
        IUser GetUserByExternalUserName(string userName, string providerName);
        bool IsUserExist(string email);

        IActivationToken ResetUserPassword(Guid userId);
        IActivationToken ResetUserPassword(string email);
        IActivationToken ChangeUserEmail(string oldEmail, string newEmail);


        void UpdatePassword(string email, string newPassword);
        bool ActivateUser(IActivationToken token, string newPassword);
        bool SetNewPassword(IActivationToken token, string newPassword);

        void CreateRole(string roleName, string description);
        IRole GetRoleById(Guid id);
        IRole GetRoleByName(string roleName);
        IEnumerable<IRole> GetUserRoles(Guid userId);
        IEnumerable<IRole> GetUserRoles(string email);
        void AddUesrToRole(Guid userId, Guid roleId);
        void AddUserToRole(string email, Guid roleId);
        bool IsUserInRole(string email, Guid roleId);
        bool IsUserInRole(Guid userId, Guid roleId);

    }
}
