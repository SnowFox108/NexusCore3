using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Entities.MailTemplates
{
    public class MailTemplate : Entity
    {
        [Required]
        public Guid WebsiteId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Subject { get; set; }
        public string BodyTemplate { get; set; }
        public bool IsBodyHtml { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string ReplyTo { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public MailPriority Priority { get; set; }

    }
}
