
namespace NexusCore.Infrasructure.Adapter.Messager
{
    public interface ISmsSender
    {
        void SendSms(string from, string to, string message);
    }
}
