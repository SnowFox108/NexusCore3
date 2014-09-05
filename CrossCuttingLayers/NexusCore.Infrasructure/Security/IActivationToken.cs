
namespace NexusCore.Infrasructure.Security
{
    public interface IActivationToken
    {
        string Email { get; }
        string PasswordHash { get; }

        string GetToken();

    }
}
