using NexusCore.Common.Data.Models.Clients;

namespace NexusCore.Common.Services.ClientServices
{
    public interface IClientDepartmentPrimitive
    {
        void CreateDepartment(ClientDepartmentModel department);
    }
}
