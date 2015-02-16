using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NexusCore.Common.Adapter.ErrorHandlers;
using NexusCore.Common.Data.Models.Installation;
using NexusCore.Common.Infrastructure;
using NexusCore.Common.Resources;
using NexusCore.Infrasructure.Security;

namespace ClientTest
{
    public class RegisterNewUser
    {
        private readonly IAuthenticationManager _authenticationManager;

        public RegisterNewUser()
        {
            _authenticationManager = EngineContext.Instance.DiContainer.GetInstance<IAuthenticationManager>();

            CreateAdministrator(new InstallationAdministratorModel
            {
                Title = WebFormText.FormValue_Mr,
                Email = "me@jie.tel",
                FirstName = "Ding",
                LastName = "Jie",
                NewPassword = "Password123",
                ConfirmPassword = "Password123"
            });
        }

        private void CreateAdministrator(InstallationAdministratorModel admin)
        {

            var token = _authenticationManager.CreateUser(admin.Title,
                GetFriendlyUserName(admin.UserName, admin.FirstName, admin.LastName),
                admin.Email,
                admin.FirstName,
                admin.LastName,
                admin.PhoneNumber,
                true);

            _authenticationManager.ActivateUser(token, admin.NewPassword);

            var user = _authenticationManager.GetUserByEmail(admin.Email);
            if (user == null)
            {
                ErrorAdapter.ModelState.AddModelError("installation", "Create Administrator failed");
                return;
            }

            var adminRole = _authenticationManager.GetRoleByName(DefaultUserRoles.Administrators);
            _authenticationManager.AddUesrToRole(user.Id, adminRole.Id);

        }

        private string GetFriendlyUserName(string userName, string firstName, string lastName)
        {
            return userName ?? string.Format("{0} {1}", firstName, lastName);
        }

    }
}
