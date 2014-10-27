
namespace NexusCore.Infrasructure.Adapter.IdGenerator
{
    public interface IFriendlyIdProvider
    {
        string GetFriendlyId(string prefix, string suffix = "");
    }
}
