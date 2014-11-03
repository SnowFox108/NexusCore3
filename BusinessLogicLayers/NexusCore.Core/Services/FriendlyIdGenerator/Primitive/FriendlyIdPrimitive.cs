using System.Linq;
using NexusCore.Common.Data.Entities.Misc;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Specifications;
using NexusCore.Common.Infrastructure;
using NexusCore.Common.Services.FriendlyIdServices;
using NexusCore.Data.Infrastructure;
using NexusCore.Infrasructure.Security;

namespace NexusCore.Core.Services.FriendlyIdGenerator.Primitive
{
    public class FriendlyIdPrimitive : IFriendlyIdPrimitive
    {
        public string GetFriendlyId(string prefix, string suffix = "")
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new ContentContext(), EngineContext.Instance.DiContainer.GetInstance<ICurrentUserProvider>()))
            {
                var friendlyIdCounter =
                    unitOfWork.Repository<FriendlyIdCounter>()
                        .Get(FriendlyIdSpecifications.Counter(prefix, suffix))
                        .FirstOrDefault();

                if (friendlyIdCounter == null)
                {
                    friendlyIdCounter = new FriendlyIdCounter
                    {
                        Prefix = prefix.ToUpper(),
                        Counter = 1001,
                        Suffix = suffix.ToUpper()
                    };

                    unitOfWork.Repository<FriendlyIdCounter>().Insert(friendlyIdCounter);
                    unitOfWork.SaveChanges();
                }
                else
                {
                    friendlyIdCounter.Counter++;
                    unitOfWork.Repository<FriendlyIdCounter>().Update(friendlyIdCounter);
                    unitOfWork.SaveChanges();
                }

                return string.Format("{0}{1}{2}", friendlyIdCounter.Prefix, friendlyIdCounter.Counter,
                    friendlyIdCounter.Suffix);
            }
        }
    }
}
