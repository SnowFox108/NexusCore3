using System.Linq;
using NexusCore.Common.Data.Entities.Misc;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Specifications;
using NexusCore.Common.Services.FriendlyIdServices;

namespace NexusCore.Core.Services.FriendlyIdGenerator.Primitive
{
    public class FriendlyIdPrimitive : IFriendlyIdPrimitive
    {

        private readonly IUnitOfWork _unitOfWork;

        public FriendlyIdPrimitive(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string GetFriendlyId(string prefix, string suffix = "")
        {
            var friendlyIdCounter =  _unitOfWork.Repository<FriendlyIdCounter>().Get(FriendlyIdSpecifications.Counter(prefix, suffix)).FirstOrDefault();

            if (friendlyIdCounter == null)
            {
                friendlyIdCounter = new FriendlyIdCounter
                {
                    Prefix = prefix.ToUpper(),
                    Counter = 1001,
                    Suffix = suffix.ToUpper()
                };

                _unitOfWork.Repository<FriendlyIdCounter>().Insert(friendlyIdCounter);
                _unitOfWork.SaveChanges();
            }
            else
            {
                friendlyIdCounter.Counter++;
                _unitOfWork.Repository<FriendlyIdCounter>().Update(friendlyIdCounter);
                _unitOfWork.SaveChanges();
            }

            return string.Format("{0}{1}{2}", friendlyIdCounter.Prefix, friendlyIdCounter.Counter,
                friendlyIdCounter.Suffix);
        }
    }
}
