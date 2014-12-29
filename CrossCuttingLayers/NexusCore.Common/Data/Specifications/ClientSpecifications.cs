using NexusCore.Common.Data.Entities.Clients;
using NexusCore.Common.Data.Specification;
using NexusCore.Common.Infrastructure;
using NexusCore.Infrasructure.Data;
using System;

namespace NexusCore.Common.Data.Specifications
{
    public class ClientSpecifications
    {
        public static ISpecification<Client> GetClient(Guid clientId)
        {
            Specification<Client> spec = new TrueSpecification<Client>();

            spec &= new DirectSpecification<Client>(c => c.Id == clientId);

            if (!EngineContext.Instance.CurrentUser.IsAdmin)
                spec &= new DirectSpecification<Client>(c => c.IsActive);

            return spec;
        }
    }
}
