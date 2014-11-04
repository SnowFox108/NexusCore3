using NexusCore.Infrasructure.Adapter.ErrorHandlers;

namespace NexusCore.Common.Adapter.ErrorHandlers
{
    public class SimpleErrorModel : IErrorModel
    {
        public string Key { get; set; }
        public string ErrorMessage { get; set; }
    }
}
