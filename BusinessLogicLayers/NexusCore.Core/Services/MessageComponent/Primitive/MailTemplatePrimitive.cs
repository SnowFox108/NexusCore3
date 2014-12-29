using System;
using NexusCore.Common.Data.Entities.MailTemplates;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Services.MessageServices;
using NexusCore.Core.Services.Infrastructure;

namespace NexusCore.Core.Services.MessageComponent.Primitive
{
    public class MailTemplatePrimitive : BasePrimitiveService, IMailTemplatePrimitive
    {
        public MailTemplatePrimitive(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public MailTemplate GetMailTemplate(Guid mailTemplateId)
        {
            return UnitOfWork.Repository<MailTemplate>().GetById(mailTemplateId);
        }
    }
}
