using System;
using NexusCore.Common.Data.Entities.Clients;
using NexusCore.Common.Security;
using NexusCore.Infrasructure.Data;
using NexusCore.Common.Data.Specification;

namespace NexusCore.Common.Data.Specifications
{
    public class ClientSpecifications
    {
        public static ISpecification<Client> GetClient(Guid clientId)
        {
            Specification<Client> spec = new TrueSpecification<Client>();

            spec &= new DirectSpecification<Client>(c => c.Id == clientId);

            if (!CurrentUserProvider.IsAdmin)
                spec &= new DirectSpecification<Client>(c => c.IsActive);

            return spec;
        }
    }
}
