using NexusCore.Common.Helper;
using NexusCore.Infrasructure.Adapter.IdGenerator;

namespace NexusCore.Core.Adapter.IdGenerator
{
    public class TimeBasedFriendlyIdProvider : IFriendlyIdProvider
    {
        public string GetFriendlyId(string prefix, string suffix = "")
        {
            return string.Format("{0}{1}{2}", prefix, GetFriendlyId(), suffix);
        }

        private string GetFriendlyId()
        {
            var timeNow = DateFormater.DateTimeNow;
            return string.Format("{0}{1}-{2}", 
                timeNow.ToString("yy"), timeNow.DayOfYear, 
                timeNow.TimeOfDay.TotalMilliseconds);
        }
    }
}
