using System.Collections.Generic;
using NexusCore.Common.Data.Models.CommonModels;

namespace NexusCore.Common.Data.Models.Memberships
{
    public class UserManagerModel
    {
        public IEnumerable<UserModel> Users { get; set; }
        public PaginationModel Paging { get; set; }
    }
}
