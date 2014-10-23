using System;
using System.Linq;
using NexusCore.Common.Data.Entities.SourceTree;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.Installation;
using NexusCore.Common.Data.Models.SourceTree;
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
            return !_aggregateServices.PrimitiveServices.SourceTreePrimitive.IsNodeExist(SourceTreeRoot.MasterNode.Id);
        }

        public void Setup(InstallationModel installation)
        {
            if (!IsFirstTime()) 
                throw new Exception("System already installed, you can't run installation again.");

            // build user and roles
            CreateAdministratorRole();
            CreateAdministrator(installation.Administrator);

            // creat default client
            CreateDefaultClient();

            // finishing install
            CreateMasterNode();
        }

        private void CreateDefaultClient()
        {
            throw new NotImplementedException();
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

        private void CreateMasterNode()
        {
            _unitOfWork.Repository<SourceTree>().Insert(SourceTreeRoot.MasterNode);
            _unitOfWork.SaveChanges();
        }

    }
}
