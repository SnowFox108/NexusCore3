using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexusCore.Admin.UILogic.ViewModels.ControlPanel;

namespace NexusCore.Admin.UILogic.Infrastructure
{
    public class GeneralPageMessages
    {
        public static GeneralPage.Message AddSuccess(params string[] messages)
        {
            var container = new GeneralPage.Message();
            container.AddWarningFromErrorAdapter();

            foreach (var message in messages)
            {
                container.MessageDetails.Add(new GeneralPage.Message.MessageDetail
                {
                    Level = GeneralPage.MessageType.Success,
                    Title = "Success",
                    Text = message
                });                
            }

            return container;
        }
    }
}
