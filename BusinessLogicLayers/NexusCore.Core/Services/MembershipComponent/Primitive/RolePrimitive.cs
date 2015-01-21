using System;
using NexusCore.Common.Data.Entities.Membership;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.Memberships;
using NexusCore.Common.Data.Specifications;
using NexusCore.Common.Helper.Extensions;
using NexusCore.Common.Services.MembershipServices;
using NexusCore.Core.Services.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace NexusCore.Core.Services.MembershipComponent.Primitive
{
    public class RolePrimitive: BasePrimitiveService, IRolePrimitive
    {
        public RolePrimitive(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public int GetRoleCount(RoleSearchFilter searchFilter)
        {
            return UnitOfWork.Repository<Role>().Get(MembershipSpecifications.GetRole(searchFilter)).Count();
        }

        public IEnumerable<Role> GetRoles(RoleSearchFilter searchFilter)
        {
            return UnitOfWork.Repository<Role>()
                .Get(MembershipSpecifications.GetRole(searchFilter),
                r => r.OrderBy(searchFilter.Filter.Sorting.SortOrder, searchFilter.Filter.Sorting.SortDirection),
                pageNumber: searchFilter.Filter.Paging.CurrentPage, pageSize: searchFilter.Filter.Paging.ItemsPerPage);
        }

        public Role GetRole(Guid roleId)
        {
            return UnitOfWork.Repository<Role>().GetById(roleId);
        }

        public void UpdateRole(Role role)
        {
            UnitOfWork.Repository<Role>().Update(role);
        }

        public void DeleteRole(Role role)
        {
            UnitOfWork.Repository<Role>().Delete(role);
        }
    }
}
