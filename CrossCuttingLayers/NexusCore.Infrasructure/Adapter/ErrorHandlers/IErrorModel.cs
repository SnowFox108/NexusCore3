
using NexusCore.Infrasructure.Models.Enums;

namespace NexusCore.Infrasructure.Adapter.ErrorHandlers
{
    public interface IErrorModel
    {
        string Key { get; set; }
        LogLevel Level { get; set; }
        string ErrorMessage { get; set; }
    }
}
