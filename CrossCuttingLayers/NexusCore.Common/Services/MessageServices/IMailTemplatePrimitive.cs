using System;
using NexusCore.Common.Data.Entities.MailTemplates;

namespace NexusCore.Common.Services.MessageServices
{
    public interface IMailTemplatePrimitive
    {
        MailTemplate GetMailTemplate(Guid mailTemplateId);
    }
}
