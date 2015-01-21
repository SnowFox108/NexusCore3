using System.Collections.Generic;
using NexusCore.Common.Data.Models.CommonModels;

namespace NexusCore.Common.Data.Models.Memberships
{
    public class RoleManagerModel
    {
        public IEnumerable<RoleModel> Roles { get; set; }
        public PaginationModel Paging { get; set; }
    }
}
