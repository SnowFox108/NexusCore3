using NexusCore.Common.Services.MessagerServices;
using NexusCore.Infrasructure.Adapter.Messager;

namespace NexusCore.Core.Utilities.Messager
{
    public class MessageService : IMessageService
    {
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;

        public MessageService(IEmailSender emailSender, ISmsSender smsSender)
        {
            _smsSender = smsSender;
            _emailSender = emailSender;
        }
    }
}
