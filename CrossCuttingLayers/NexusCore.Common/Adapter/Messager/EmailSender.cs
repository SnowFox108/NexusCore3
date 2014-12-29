using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using NexusCore.Common.Helper;
using NexusCore.Infrasructure.Adapter.Messager;

namespace NexusCore.Common.Adapter.Messager
{
    public class EmailSender : IEmailSender
    {
        public MailMessage CreateEmail(string subject, string body, bool isBodyHtml, MailPriority priority, Encoding bodyEncoding, string from, string to, string replyTo = null, string bccTo = null, IDictionary<string, string> tokenValues = null, IDictionary<string, Stream> attachments = null)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(@from.ToLower()),
                Subject = tokenValues == null ? subject : TextMessage.ReplaceTokens(subject, tokenValues),
                Body = tokenValues == null ? body : TextMessage.ReplaceTokens(body, tokenValues),
            };

            mailMessage.To.Add(to);

            if (!string.IsNullOrEmpty(replyTo))
                mailMessage.ReplyToList.Add(replyTo);

            if (!string.IsNullOrEmpty(bccTo))
                mailMessage.Bcc.Add(bccTo);

            if (attachments != null)
            {
                foreach (var attach in attachments.Select(a => new Attachment(a.Value, a.Key)))
                    mailMessage.Attachments.Add(attach);
            }

            mailMessage.Priority = priority;
            mailMessage.IsBodyHtml = isBodyHtml;
            mailMessage.BodyEncoding = bodyEncoding;

            return mailMessage;
        }

        public void SendEmail(string subject, string body, bool isBodyHtml, MailPriority priority, Encoding bodyEncoding,
            string from, string to, string replyTo = null, string bccTo = null,
            IDictionary<string, string> tokenValues = null,
            IDictionary<string, Stream> attachments = null)
        {
            SendEmail(CreateEmail(
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
                attachments
                ));
        }

        public virtual void SendEmail(MailMessage message)
        {
            var client = new SmtpClient();
            client.Send(message);
        }
    }
}
