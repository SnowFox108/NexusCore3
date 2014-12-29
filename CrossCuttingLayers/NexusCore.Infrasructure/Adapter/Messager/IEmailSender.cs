using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace NexusCore.Infrasructure.Adapter.Messager
{
    public interface IEmailSender
    {
        MailMessage CreateEmail(
            string subject,
            string body,
            bool isBodyHtml,
            MailPriority priority,
            Encoding bodyEncoding,
            string from,
            string to,
            string replyTo = null,
            string bccTo = null,
            IDictionary<string, string> tokenValues = null,
            IDictionary<string, Stream> attachments = null);

        void SendEmail(
            string subject,
            string body,
            bool isBodyHtml,
            MailPriority priority,
            Encoding bodyEncoding,
            string from,
            string to,
            string replyTo = null,
            string bccTo = null,
            IDictionary<string, string> tokenValues = null,
            IDictionary<string, Stream> attachments = null);

        void SendEmail(MailMessage message);
    }
}
