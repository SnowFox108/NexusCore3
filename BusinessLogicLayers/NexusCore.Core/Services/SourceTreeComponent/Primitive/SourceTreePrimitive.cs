using System;
using System.Collections.Generic;
using NexusCore.Common.Data.Entities.SourceTree;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.SourceTree;
using NexusCore.Common.Data.Specifications;
using NexusCore.Common.Services.Primitive;

namespace NexusCore.Core.Services.SourceTreeComponent.Primitive
{
    public class SourceTreeService : ISourceTreePrimitive
    {
        private readonly IUnitOfWork _unitOfWork;

        public SourceTreeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<SourceTree> GetChildNodes(Guid parentId,
            SourceTreeItemType itemType = SourceTreeItemType.None)
        {
            var result = _unitOfWork.Repository<SourceTree>().Get(SourceTreeSpecifications.ChildNodes(parentId, itemType));

            if (result == null)
                return new List<SourceTree>();
            return result;
        }

        public IEnumerable<SourceTree> GetChildNodes(Guid parentId, IEnumerable<SourceTreeItemType> itemTypes)
        {
            var result = _unitOfWork.Repository<SourceTree>().Get(SourceTreeSpecifications.ChildNodes(parentId, itemTypes));

            if (result == null)
                return new List<SourceTree>();
            return result;            
        }
    }
}
