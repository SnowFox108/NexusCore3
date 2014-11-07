using NexusCore.Common.Data.Entities.Clients;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.Clients;
using NexusCore.Common.Helper.Extensions;
using NexusCore.Common.Services.ClientServices;
using NexusCore.Core.Services.Infrastructure;

namespace NexusCore.Core.Services.ClientComponent.Primitive
{
    public class ClientDepartmentPrimitive : BasePrimitiveService, IClientDepartmentPrimitive
    {
        public ClientDepartmentPrimitive(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void CreateDepartment(ClientDepartmentModel department)
        {
            UnitOfWork.Repository<ClientDepartment>().Insert(department.MapTo<ClientDepartment>());
        }

    }
}
