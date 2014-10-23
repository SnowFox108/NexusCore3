using NexusCore.Common.Data.Entities.Misc;
using NexusCore.Infrasructure.Data;
using NexusCore.Common.Data.Specification;

namespace NexusCore.Common.Data.Specifications
{
    public static class FriendlyIdSpecifications
    {
        public static ISpecification<FriendlyIdCounter> Counter(string prefix, string suffix)
        {
            Specification<FriendlyIdCounter> specification = new TrueSpecification<FriendlyIdCounter>();

            specification &= new DirectSpecification<FriendlyIdCounter>(q => q.Prefix == prefix.ToUpper());

            if (!string.IsNullOrEmpty(suffix))
                specification &= new DirectSpecification<FriendlyIdCounter>(q => q.Suffix == suffix.ToUpper());

            return specification;
        }
    }
}
