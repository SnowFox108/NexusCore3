using NexusCore.Common.Data.Models.Clients;

namespace NexusCore.Common.Data.Models.Installation
{
    public class InstallationClientModel
    {
        public ClientModel Client { get; set; }
        public ClientDepartmentModel ClientDepartment { get; set; }
        public bool IsSkip { get; set; }
    }
}
