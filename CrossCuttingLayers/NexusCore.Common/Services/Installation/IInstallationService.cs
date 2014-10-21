
using NexusCore.Common.Data.Models.Installation;

namespace NexusCore.Common.Services.Installation
{
    public interface IInstallationService
    {
        bool IsFirstTime();
        void Setup(InstallationModel installation);
    }
}
