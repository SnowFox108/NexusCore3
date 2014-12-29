using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using NexusCore.Common.Adapter.ErrorHandlers;
using NexusCore.Common.Data.Entities.Clients;
using NexusCore.Common.Data.Entities.Membership;
using NexusCore.Common.Data.Entities.SourceTrees;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.Installation;
using NexusCore.Common.Data.Models.SourceTrees;
using NexusCore.Common.Helper;
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
        private readonly IUnitOfWorkAsyncFactory _unitOfWorkFactory;

        public InstallationService(IUnitOfWorkAsyncFactory unitOfWorkFacotry, IUnitOfWork unitOfWork, IPrimitiveServices primitiveServices, IAggregateServices aggregateServices, IAuthenticationManager authenticationManager) : base(unitOfWork, primitiveServices, aggregateServices)
        {
            _authenticationManager = authenticationManager;
            _unitOfWorkFactory = unitOfWorkFacotry;
        }

        public bool IsFirstTime()
        {
            return !PrimitiveServices.SourceTreePrimitive.IsNodeExist(SourceTreeRoot.MasterNode.Id);
        }

        public void Setup(InstallationModel installation)
        {
            if (!IsFirstTime())
            {
                ErrorAdapter.ModelState.AddModelError("", "Something is wrong here", logCode: LogCode.CriticalInstallationRepeated);
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
            //using (var unitOfWork = _unitOfWorkFactory.Create())
            //{
            //    if (unitOfWork.Repository<User>().Get(u => u.Email == admin.Email).Any())
            //        throw new ValidationException("Email address is already registered");

            //    var timeNow = DateFormater.DateTimeNow;
            //    var userId = Guid.NewGuid();

            //    unitOfWork.Repository<User>().Insert(new User
            //    {
            //        Id = userId,
            //        Email = admin.Email,
            //        UserName = GetFriendlyUserName(admin.UserName, admin.FirstName, admin.LastName),
            //        Title = admin.Title,
            //        FirstName = admin.FirstName,
            //        LastName = admin.LastName,
            //        PhoneNumber = admin.PhoneNumber,
            //        LastActivityDate = timeNow,
            //        PasswordSalt = GenerateSalt(),
            //        CreatedBy = userId,
            //        CreatedDate = timeNow,
            //        UpdatedBy = userId,
            //        UpdatedDate = timeNow
            //    });

            //    unitOfWork.SaveChanges();
            //}

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

            // Login Admin
            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(user.Email, "Passport"), null);
        }

        private string GetFriendlyUserName(string userName, string firstName, string lastName)
        {
            return userName ?? string.Format("{0} {1}", firstName, lastName);
        }
        private string GenerateSalt()
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(Guid.NewGuid().ToString().Substring(16)));
        }

        private void CreateMasterNode()
        {
            UnitOfWork.Repository<SourceTree>().Insert(SourceTreeRoot.MasterNode);
            PrimitiveServices.PermissionPrimitive.RemoveInheritPermission(SourceTreeRoot.MasterNode.Id);
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
