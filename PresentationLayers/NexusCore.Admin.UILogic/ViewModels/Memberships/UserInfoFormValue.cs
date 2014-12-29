using System.Collections.Generic;
using System.Web.Mvc;
using NexusCore.Common.Resources;

namespace NexusCore.Admin.UILogic.ViewModels.Memberships
{
    public class UserInfoFormValue
    {
        public List<SelectListItem> TitleTypes { get; private set; }

        public UserInfoFormValue()
        {
            TitleTypes = new List<SelectListItem>
            {
                new SelectListItem {Value = "Mr", Text = WebFormText.FormValue_Mr},
                new SelectListItem {Value = "Ms", Text = WebFormText.FormValue_Ms},
                new SelectListItem {Value = "Mrs", Text = WebFormText.FormValue_Mrs},
                new SelectListItem {Value = "Miss", Text = WebFormText.FormValue_Miss}
            };
        }
    }
}
