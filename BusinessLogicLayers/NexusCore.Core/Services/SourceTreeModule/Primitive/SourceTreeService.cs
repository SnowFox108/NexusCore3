using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexusCore.Common.Data.Infrastructure;

namespace NexusCore.Core.Services.Primitive
{
    public class SourceTreeService
    {
        private IUnitOfWork _unitOfWork;

        public SourceTreeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
