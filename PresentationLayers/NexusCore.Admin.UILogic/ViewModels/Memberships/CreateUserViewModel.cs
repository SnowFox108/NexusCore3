
namespace NexusCore.Admin.UILogic.ViewModels.Memberships
{
    public class CreateUserViewModel
    {
        public UserInfoFormValue FormValue { get; set; }
        public UserViewModel User { get; set; }

        public CreateUserViewModel()
        {
            FormValue = new UserInfoFormValue();
        }
    }
}
