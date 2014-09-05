namespace NexusCore.Infrasructure.Web
{
    public interface IApiUrlProvider
    {
        string ApiUrl { get; }
        string AppKey { get; }
    }
}
