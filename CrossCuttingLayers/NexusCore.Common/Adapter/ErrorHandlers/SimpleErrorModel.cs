using NexusCore.Infrasructure.Adapter.ErrorHandlers;
using NexusCore.Infrasructure.Models.Enums;

namespace NexusCore.Common.Adapter.ErrorHandlers
{
    public class SimpleErrorModel : IErrorModel
    {
        public string Key { get; set; }
        public LogLevel Level { get; set; }
        public string ErrorMessage { get; set; }
    }
}
