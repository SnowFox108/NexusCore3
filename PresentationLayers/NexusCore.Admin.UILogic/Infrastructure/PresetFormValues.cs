using System.Collections.Generic;
using System.Web.Mvc;
using NexusCore.Common.Resources;

namespace NexusCore.Admin.UILogic.Infrastructure
{
    public static class PresetFormValues
    {
        public static List<SelectListItem> Titles(string value = "")
        {
            return new List<SelectListItem>
            {
                new SelectListItem {Value = "Mr", Text = WebFormText.FormValue_Mr, Selected = value == "Mr"},
                new SelectListItem {Value = "Ms", Text = WebFormText.FormValue_Ms, Selected = value == "Ms"},
                new SelectListItem {Value = "Mrs", Text = WebFormText.FormValue_Mrs, Selected = value == "Mrs"},
                new SelectListItem {Value = "Miss", Text = WebFormText.FormValue_Miss, Selected = value == "Miss"}
            };
        }
    }
}
