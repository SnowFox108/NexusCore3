using System;
using System.Linq;
using System.Reflection;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.Installation;
using NexusCore.Common.Services;
using NexusCore.Common.Services.Installation;
using NexusCore.Infrasructure.Security;

namespace NexusCore.Core.Services.InstallationComponent
{
    public class InstallationService : IInstallationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAggregateServices _aggregateServices;
        private readonly IAuthenticationManager _authenticationManager;

        public InstallationService(IUnitOfWork unitOfWork, IAggregateServices aggregateServices, IAuthenticationManager authenticationManager)
        {
            _unitOfWork = unitOfWork;
            _aggregateServices = aggregateServices;
            _authenticationManager = authenticationManager;
        }

        public bool IsFirstTime()
        {
            return true;
        }

        public void Setup(InstallationModel installation)
        {
            CreateAdministratorRole();
            CreateAdministrator(installation.Administrator);
        }

        private void CreateAdministratorRole()
        {
            var roles = typeof (DefaultUserRoles).GetFields().ToList();
            foreach (var roleName in roles.Select(role => role.GetValue(null).ToString()))
                _authenticationManager.CreateRole(roleName, roleName);
        }

        private void CreateAdministrator(InstallationAdministratorModel admin)
        {
            _authenticationManager.CreateUser(
                admin.Title,
                admin.UserName,
                admin.Email,
                admin.FirstName,
                admin.LastName,
                admin.PhoneNumber);
        }
    }
}
