using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NexusCore.Common.Data.Entities.Membership;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.CommonModels;
using NexusCore.Common.Data.Models.Memberships;
using NexusCore.Common.Helper.Extensions;
using NexusCore.Common.Services;
using NexusCore.Common.Services.MembershipServices;
using NexusCore.Common.Services.MessagerServices;
using NexusCore.Core.Services.Infrastructure;
using NexusCore.Infrasructure.Model.Enums;
using NexusCore.Infrasructure.Security;

namespace NexusCore.Core.Services.MembershipComponent
{
    public class MembershipService : BaseComponentService , IMembershipService
    {

        private readonly IAuthenticationManager _userManager;
        private readonly IMessageService _messageService;
        private readonly IAuthenticationManager _simpleAuthenticationManager;

        public MembershipService(IUnitOfWork unitOfWork, 
            IPrimitiveServices primitiveServices, 
            IAggregateServices aggregateServices, 
            IAuthenticationManager userManager,
            IMessageService messageService, IAuthenticationManager simpleAuthenticationManager) : base(unitOfWork, primitiveServices, aggregateServices)
        {
            _userManager = userManager;
            _messageService = messageService;
            _simpleAuthenticationManager = simpleAuthenticationManager;
        }

        public void DeleteUser(UserModel user)
        {
            PrimitiveServices.UserPrimitive.DeleteUser(user.MapTo<User>());
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
                userModel.CreatedByUser = ((User)_simpleAuthenticationManager.GetUser(userModel.CreatedBy)).MapTo<CurrentUserModel>();
                userModel.UpdatedByUser = ((User)_simpleAuthenticationManager.GetUser(userModel.UpdatedBy)).MapTo<CurrentUserModel>();
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
            _userManager.CreateUser(title, userName, email, firstName, lastName, phoneNumber);

            // send Email depend on which website send different register Email
            //var mailTemplateid = new Guid(); // need to be update

            //var mailTemplate = PrimitiveServices.MailTemplatePrimitive.GetMailTemplate(mailTemplateid);
            //if (mailTemplate != null)
            //{
            //    _messageService.SendEmail(mailTemplate.Subject, mailTemplate.BodyTemplate, mailTemplate.IsBodyHtml,
            //        mailTemplate.Priority, Encoding.UTF8, mailTemplate.From, email, mailTemplate.ReplyTo,
            //        mailTemplate.Bcc);
            //}
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
            PrimitiveServices.UserPrimitive.UpdateUser(user.MapTo<User>());
        }


    }
}
