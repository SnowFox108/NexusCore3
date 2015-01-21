using NexusCore.Common.Adapter.ErrorHandlers;

namespace NexusCore.Admin.UILogic.ViewModels.ControlPanel
{
    public static class InfoBoxMessageExtension
    {
        public static void AddWarningFromErrorAdapter(this GeneralPage.Message messages)
        {
            if (ErrorAdapter.ModelState.IsWarning)
            {
                foreach (var errorModel in ErrorAdapter.ModelState.Warnings)
                {
                    messages.MessageDetails.Add(new GeneralPage.Message.MessageDetail
                    {
                        Level = GeneralPage.MessageType.Warning,
                        Title = string.IsNullOrEmpty(errorModel.Key) ? "Warning" : errorModel.Key,
                        Text = errorModel.ErrorMessage
                    });
                }
            }
        }
    }
}
