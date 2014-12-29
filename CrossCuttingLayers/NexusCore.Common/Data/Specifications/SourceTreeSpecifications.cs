using System.Collections.Generic;
using System.Linq;
using NexusCore.Common.Data.Entities.SourceTrees;
using NexusCore.Common.Data.Enums;
using NexusCore.Common.Data.Models.SourceTrees;
using NexusCore.Common.Data.Specification;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Specifications
{
    public static class SourceTreeSpecifications
    {

        public static ISpecification<SourceTree> ChildNodes(SourceTreeItemType itemType = SourceTreeItemType.None)
        {
            Specification<SourceTree> specification = new TrueSpecification<SourceTree>();

            //specification &= new DirectSpecification<SourceTree>(s => s.ParentId == parentId);

            if (itemType != SourceTreeItemType.None)
                specification &= new DirectSpecification<SourceTree>(s => s.ItemType == itemType);

            return specification;
        }

        public static ISpecification<SourceTree> ChildNodes(IEnumerable<SourceTreeItemType> itemTypes)
        {
            Specification<SourceTree> specification = new TrueSpecification<SourceTree>();

            //specification &= new DirectSpecification<SourceTree>(s => s.ParentId == parentId);
            specification &= new DirectSpecification<SourceTree>(s => itemTypes.Contains(s.ItemType));

            return specification;
        }

    }
}
