using System;
using System.Collections.Generic;
using System.Linq;
using NexusCore.Common.Data.Entities.SourceTree;
using NexusCore.Common.Data.Models.SourceTree;
using NexusCore.Common.Data.Specification;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Specifications
{
    public static class SourceTreeSpecifications
    {
        public static ISpecification<SourceTree> ChildNodes(Guid parentId, SourceTreeItemType itemType = SourceTreeItemType.None)
        {
            Specification<SourceTree> specification = new TrueSpecification<SourceTree>();

            specification &= new DirectSpecification<SourceTree>(s => s.ParentId == parentId);

            if (itemType != SourceTreeItemType.None)
                specification &= new DirectSpecification<SourceTree>(s => s.ItemType == itemType);

            return specification;
        }

        public static ISpecification<SourceTree> ChildNodes(Guid parentId, IEnumerable<SourceTreeItemType> itemTypes)
        {
            Specification<SourceTree> specification = new TrueSpecification<SourceTree>();

            specification &= new DirectSpecification<SourceTree>(s => s.ParentId == parentId);
            specification &= new DirectSpecification<SourceTree>(s => itemTypes.Contains(s.ItemType));

            return specification;
        }

    }
}
