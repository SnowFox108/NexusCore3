
namespace NexusCore.Infrasructure.Adapter.ErrorHandlers
{
    public interface IErrorModel
    {
        string Key { get; set; }
        string ErrorMessage { get; set; }
    }
}
