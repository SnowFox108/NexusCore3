using NexusCore.Common.Data.Models.Installation;

namespace NexusCore.Common.Services.Installation
{
    public interface IInstallationService
    {
        void CreateAdministrator(InstallationAdministratorModel admin);
    }
}
