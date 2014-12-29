using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;
using NexusCore.Infrasructure.Adapter.Messager;

namespace NexusCore.Common.Services.MessagerServices
{
    public interface IMessageService
    {
        IEmailSender EmailSender { get; }
        ISmsSender SmsSender { get; }

        void SendEmail(string subject, string body, bool isBodyHtml, MailPriority priority, Encoding bodyEncoding,
            string from, string to, string replyTo = null, string bccTo = null,
            IDictionary<string, string> tokenValues = null,
            IDictionary<string, Stream> attachments = null);
    }
}
