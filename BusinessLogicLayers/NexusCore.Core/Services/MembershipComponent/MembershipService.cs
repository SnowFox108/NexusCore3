using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NexusCore.Common.Adapter.ErrorHandlers;
using NexusCore.Common.Data.Entities.Membership;
using NexusCore.Common.Data.Enums;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.CommonModels;
using NexusCore.Common.Data.Models.Memberships;
using NexusCore.Common.Helper.Extensions;
using NexusCore.Common.Services;
using NexusCore.Common.Services.MembershipServices;
using NexusCore.Common.Services.MessagerServices;
using NexusCore.Core.Services.Infrastructure;
using NexusCore.Infrasructure.Models.Enums;
using NexusCore.Infrasructure.Security;

namespace NexusCore.Core.Services.MembershipComponent
{
    public class MembershipService : BaseComponentService , IMembershipService
    {

        private readonly IAuthenticationManager _userManager;
        private readonly IMessageService _messageService;

        public MembershipService(IUnitOfWork unitOfWork, 
            IPrimitiveServices primitiveServices, 
            IAggregateServices aggregateServices, 
            IAuthenticationManager userManager,
            IMessageService messageService) : base(unitOfWork, primitiveServices, aggregateServices)
        {
            _userManager = userManager;
            _messageService = messageService;
        }

        #region Users

        public void DeleteUser(UserModel user)
        {
            PrimitiveServices.UserPrimitive.DeleteUser(user.MapTo<User>());
            UnitOfWork.SaveChanges();
        }

        public UserManagerModel GetUsers(UserSearchFilter searchFilter)
        {
            return new UserManagerModel
            {
                Users = MapToUserModel(PrimitiveServices.UserPrimitive.GetUsers(searchFilter)),
                Paging = new PaginationModel
                {
                    TotalItems = PrimitiveServices.UserPrimitive.GetUserCount(searchFilter),
                    ItemsPerPage = searchFilter.Filter.Paging.ItemsPerPage,
                    CurrentPage = searchFilter.Filter.Paging.CurrentPage
                }
            };
        }

        private IEnumerable<UserModel> MapToUserModel(IEnumerable<User> users)
        {
            var result = users.MapTo<UserModel>();
            foreach (var userModel in result)
            {
                userModel.CreatedByUser = ((User)_userManager.GetUser(userModel.CreatedBy)).MapTo<CurrentUserModel>();
                userModel.UpdatedByUser = ((User)_userManager.GetUser(userModel.UpdatedBy)).MapTo<CurrentUserModel>();
                yield return userModel;
            }            
        }

        public UserModel GetUser(Guid userId)
        {
            return PrimitiveServices.UserPrimitive.GetUser(userId).MapTo<UserModel>();
        }

        public void RegisterNewUser(Guid websiteId, string title, string userName, string email, string firstName, string lastName,
            string phoneNumber)
        {
            var activationToken = _userManager.CreateUser(title, userName, email, firstName, lastName, phoneNumber);

            if (!ErrorAdapter.ModelState.IsValid)
                return;


            var mailTemplateid = PrimitiveServices.WebsiteSettingPrimitive.GetSettingId(websiteId,
                WebsiteSettingType.MailTemplateRegister, false);

            if (mailTemplateid != Guid.Empty)
            {
                // send Email depend on which website send different register Email
                var mailTokens = new Dictionary<string, string>
                {
                    {"Title", title},
                    {"UserName", userName},
                    {"Email", email},
                    {"FirstName", firstName},
                    {"LastName", lastName},
                    {"ActivationToken", activationToken.GetToken()}
                };

                var mailTemplate = PrimitiveServices.MailTemplatePrimitive.GetMailTemplate(mailTemplateid);
                if (mailTemplate != null)
                {
                    _messageService.SendEmail(mailTemplate.Subject, mailTemplate.BodyTemplate, mailTemplate.IsBodyHtml,
                        mailTemplate.Priority, Encoding.UTF8, mailTemplate.From, email, mailTemplate.ReplyTo,
                        mailTemplate.Bcc, mailTokens);
                }
            }
            //ErrorAdapter.ModelState.Clear(); // remove this after upgrade to warning message
        }

        public void SetupPassword(IActivationToken token, string password)
        {
            _userManager.ActivateUser(token, password);
            // send confirm email here
        }

        public void ResetUserPassword(string email)
        {
            var token = _userManager.ResetUserPassword(email);
            // send reset email here
        }

        public void UpdateUser(UserModel user)
        {
            //PrimitiveServices.UserPrimitive.UpdateUser(user.MapTo<User>());
            _userManager.UpdateUser(user.Id, user.Title, user.UserName, user.Email, user.FirstName, user.LastName,
                user.PhoneNumber);
        }

        #endregion

        #region Roles

        public void CreateRole(RoleModel role)
        {
            _userManager.CreateRole(role.RoleName, role.Description);
        }

        public void DeleteRole(Guid roleId)
        {
            var role = PrimitiveServices.RolePrimitive.GetRole(roleId);
            if (DefaultUserRoles.SystemUserRoles.Contains(role.RoleName))
            {
                ErrorAdapter.ModelState.AddModelError(logCode: LogCode.ErrorRoleNameCannotDeleteDueSystemRole);
                return;
            }
            if (RoleHasUsers(roleId))
            {
                ErrorAdapter.ModelState.AddModelError(logCode: LogCode.ErrorRoleNameCannotDeleteDueHasUser);
                return;
            }

            PrimitiveServices.RolePrimitive.DeleteRole(role);
            UnitOfWork.SaveChanges();
        }

        public bool RoleHasUsers(Guid roleId)
        {
            return PrimitiveServices.RolePrimitive.GetRole(roleId).Users.Any();
        }

        public RoleManagerModel GetRoles(RoleSearchFilter searchFilter)
        {
            return new RoleManagerModel
            {
                Roles = PrimitiveServices.RolePrimitive.GetRoles(searchFilter).MapTo<RoleModel>(),
                Paging = new PaginationModel
                {
                    TotalItems = PrimitiveServices.RolePrimitive.GetRoleCount(searchFilter),
                    ItemsPerPage = searchFilter.Filter.Paging.ItemsPerPage,
                    CurrentPage = searchFilter.Filter.Paging.CurrentPage
                }
            };
        }

        public RoleModel GetRole(Guid roleId)
        {
            return PrimitiveServices.RolePrimitive.GetRole(roleId).MapTo<RoleModel>();
        }

        public void UpdateRole(RoleModel role)
        {
            if (IsDifferFromOriginalRoleName(role) && UnitOfWork.Repository<Role>().Get(r => r.RoleName == role.RoleName).Any())
            {
                ErrorAdapter.ModelState.AddModelError("Role.RoleName", "", logCode: LogCode.ErrorRoleNameAlreadyExist);
                return;
            }

            PrimitiveServices.RolePrimitive.UpdateRole(role.MapTo<Role>());
            UnitOfWork.SaveChanges();
        }

        private bool IsDifferFromOriginalRoleName(RoleModel role)
        {
            var orgRole = PrimitiveServices.RolePrimitive.GetRole(role.Id);
            return role.RoleName != orgRole.RoleName;
        }

        #endregion

    }
}
