using NexusCore.Common.Data.Entities.Membership;
using NexusCore.Common.Data.Models.Memberships;
using NexusCore.Common.Data.Specification;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Specifications
{
    public class MembershipSpecifications
    {
        public static ISpecification<User> GetUser(UserSearchFilter searchFilter)
        {
            Specification<User> spec = new TrueSpecification<User>();

            if (!string.IsNullOrEmpty(searchFilter.Title))
                spec &= new DirectSpecification<User>(u => u.Title == searchFilter.Title);
            if (!string.IsNullOrEmpty(searchFilter.FirstName))
                spec &= new DirectSpecification<User>(u => u.FirstName.Contains(searchFilter.FirstName));
            if (!string.IsNullOrEmpty(searchFilter.LastName))
                spec &= new DirectSpecification<User>(u => u.LastName.Contains(searchFilter.LastName));
            if (!string.IsNullOrEmpty(searchFilter.Email))
                spec &= new DirectSpecification<User>(u => u.Email.Contains(searchFilter.Email));
            if (!string.IsNullOrEmpty(searchFilter.PhoneNumber))
                spec &= new DirectSpecification<User>(u => u.PhoneNumber.Contains(searchFilter.PhoneNumber));

            return spec;
        }
    }
}
