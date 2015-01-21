
using System;
using NexusCore.Common.Data.Models.Memberships;
using NexusCore.Common.Services.MembershipServices;

namespace NexusCore.Admin.UILogic.ViewModels.Memberships
{
    public class EditUserViewModel
    {
        public UserInfoFormValue FormValue { get; set; }
        public UserModel User { get; set; }

        public EditUserViewModel()
        {
            FormValue = new UserInfoFormValue();
        }

        public void InitData(IMembershipService membership, Guid userId)
        {
            User = membership.GetUser(userId);
            FormValue.Init(User.Title);
        }
    }
}
