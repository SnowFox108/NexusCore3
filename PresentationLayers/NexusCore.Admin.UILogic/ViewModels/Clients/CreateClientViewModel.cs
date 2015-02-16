using NexusCore.Common.Data.Models.Clients;

namespace NexusCore.Admin.UILogic.ViewModels.Clients
{
    public class CreateClientViewModel
    {
        public ClientInfoFormValue FormValue { get; set; }
        public ClientModel Client { get; set; }
        public ClientDepartmentModel ClientDepartment { get; set; }

        public CreateClientViewModel()
        {
            FormValue = new ClientInfoFormValue();
        }
    }
}
