using System.Linq;
using System.Security.Principal;
using System.Threading;
using NexusCore.Common.Adapter.ErrorHandlers;
using NexusCore.Common.Data.Entities.Clients;
using NexusCore.Common.Data.Entities.SourceTrees;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.Installation;
using NexusCore.Common.Data.Models.SourceTrees;
using NexusCore.Common.Helper.Extensions;
using NexusCore.Common.Services;
using NexusCore.Common.Services.InstallationServices;
using NexusCore.Core.Services.Infrastructure;
using NexusCore.Infrasructure.Models.Enums;
using NexusCore.Infrasructure.Security;

namespace NexusCore.Core.Services.InstallationComponent
{
    public class InstallationService : BaseComponentService, IInstallationService
    {
        private readonly IAuthenticationManager _authenticationManager;

        public InstallationService(IUnitOfWork unitOfWork, IPrimitiveServices primitiveServices, IAggregateServices aggregateServices, IAuthenticationManager authenticationManager) : base(unitOfWork, primitiveServices, aggregateServices)
        {
            _authenticationManager = authenticationManager;
        }

        public bool IsFirstTime()
        {
            return !PrimitiveServices.SourceTreePrimitive.IsNodeExist(SourceTreeRoot.MasterNode.Id);
        }

        public void Setup(InstallationModel installation)
        {
            if (!IsFirstTime())
            {
                ErrorAdapter.ModelState.AddModleError("", "Something is wrong here", logCode: LogCode.CriticalInstallationRepeated);
                return;
            }

            // build user and roles
            CreateAdministratorRole();
            CreateAdministrator(installation.Administrator);

            // creat master node
            CreateMasterNode();

            // creat default client
            if (!installation.Client.IsSkip)
            {
                CreateDefaultClient(installation.Client);
            }

            // finishing install
            UnitOfWork.SaveChanges();

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

            var user = _authenticationManager.GetUserByEmail(admin.Email);
            if (user == null)
            {
                ErrorAdapter.ModelState.AddModleError("installation", "Create Administrator failed");
                return;
            }

            // Login Admin
            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(user.Email, "Passport"), null);
        }

        private void CreateMasterNode()
        {
            UnitOfWork.Repository<SourceTree>().Insert(SourceTreeRoot.MasterNode);
        }

        private void CreateDefaultClient(InstallationClientModel client)
        {
            client.Client.GenerateNewIdentity();
            client.ClientDepartment.GenerateNewIdentity();

            AggregateServices.ClientAggregate.CreateClient(client.Client.MapTo<Client>(),
                client.ClientDepartment.MapTo<ClientDepartment>());
            AggregateServices.SourceTreeAggregate.CreateClientNode(client.Client.Id, client.Client.Name);
        }

    }
}
