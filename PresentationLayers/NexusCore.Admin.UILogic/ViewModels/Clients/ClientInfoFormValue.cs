using System.Collections.Generic;
using System.Web.Mvc;
using NexusCore.Admin.UILogic.Infrastructure;

namespace NexusCore.Admin.UILogic.ViewModels.Clients
{
    public class ClientInfoFormValue
    {
        public List<SelectListItem> TitleTypes { get; private set; }

        public virtual void Init(string value = "")
        {
            TitleTypes = PresetFormValues.Titles(value);
        }

    }
}
