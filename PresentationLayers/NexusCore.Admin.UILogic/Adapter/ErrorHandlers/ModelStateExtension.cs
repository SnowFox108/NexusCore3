using System.Web.Mvc;
using NexusCore.Common.Adapter.ErrorHandlers;

namespace NexusCore.Admin.UILogic.Adapter.ErrorHandlers
{
    public static class ModelStateExtension
    {
        public static void AddFromErrorAdapter(this ModelStateDictionary modelState)
        {
            if (!ErrorAdapter.ModelState.IsValid)
                foreach (var error in ErrorAdapter.ModelState.Errors)
                    modelState.AddModelError(error.Key, error.ErrorMessage);
        }
    }
}
