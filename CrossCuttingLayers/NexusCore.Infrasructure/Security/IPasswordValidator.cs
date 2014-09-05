
namespace NexusCore.Infrasructure.Security
{
    public interface IPasswordValidator
    {
        string ValidatePassword(string password);
    }
}
