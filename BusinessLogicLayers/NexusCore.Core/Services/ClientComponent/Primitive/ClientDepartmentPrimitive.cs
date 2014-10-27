using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Services.ClientServices;
using NexusCore.Core.Services.Infrastructure;

namespace NexusCore.Core.Services.ClientComponent.Primitive
{
    public class ClientDepartmentPrimitive : BasePrimitiveService, IClientDepartmentPrimitive
    {
        public ClientDepartmentPrimitive(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
