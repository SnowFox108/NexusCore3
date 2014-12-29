using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;
using NexusCore.Common.Services.MessagerServices;
using NexusCore.Infrasructure.Adapter.Messager;

namespace NexusCore.Core.Utilities.Messager
{
    public class MessageService : IMessageService
    {
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;

        public IEmailSender EmailSender
        {
            get { return _emailSender; }
        }

        public ISmsSender SmsSender
        {
            get { return _smsSender; }
        }

        public MessageService(IEmailSender emailSender, ISmsSender smsSender)
        {
            _smsSender = smsSender;
            _emailSender = emailSender;
        }

        public void SendEmail(string subject, string body, bool isBodyHtml, MailPriority priority, Encoding bodyEncoding,
            string from, string to, string replyTo = null, string bccTo = null,
            IDictionary<string, string> tokenValues = null,
            IDictionary<string, Stream> attachments = null)
        {
            _emailSender.SendEmail(
                subject,
                body,
                isBodyHtml,
                priority,
                bodyEncoding,
                from,
                to,
                replyTo,
                bccTo,
                tokenValues,
                attachments);
        }
    }
}
