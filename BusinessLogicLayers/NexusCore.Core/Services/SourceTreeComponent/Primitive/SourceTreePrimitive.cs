using System;
using System.Collections.Generic;
using System.Linq;
using NexusCore.Common.Data.Entities.SourceTrees;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.SourceTrees;
using NexusCore.Common.Data.Specifications;
using NexusCore.Common.Services.SourceTreeServices;
using NexusCore.Core.Services.Infrastructure;

namespace NexusCore.Core.Services.SourceTreeComponent.Primitive
{
    public class SourceTreePrimitive : BasePrimitiveService, ISourceTreePrimitive
    {
        public SourceTreePrimitive(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<SourceTree> GetChildNodes(Guid parentId,
            SourceTreeItemType itemType = SourceTreeItemType.None)
        {
            var result = UnitOfWork.Repository<SourceTree>().Get(SourceTreeSpecifications.ChildNodes(parentId, itemType));

            if (result == null)
                return new List<SourceTree>();
            return result;
        }

        public IEnumerable<SourceTree> GetChildNodes(Guid parentId, IEnumerable<SourceTreeItemType> itemTypes)
        {
            var result = UnitOfWork.Repository<SourceTree>().Get(SourceTreeSpecifications.ChildNodes(parentId, itemTypes));

            if (result == null)
                return new List<SourceTree>();
            return result;            
        }

        public bool IsNodeExist(Guid id)
        {
            return UnitOfWork.Repository<SourceTree>().Get(s => s.Id == id).Any();
        }

    }
}
