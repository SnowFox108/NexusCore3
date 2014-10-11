using System.Linq;
using NexusCore.Infrasructure.Security;

namespace NexusCore.Common.Security
{
    public class PasswordValidtor: IPasswordValidator
    {
        public const string ValidationError = "Password must be at least 8 characters long, and at least 1 numbers";

        public string ValidatePassword(string password)
        {
            return password.Length < 8 || password.Count(char.IsDigit) < 1 //|| password.Count(char.IsLetter) < 6
                       ? ValidationError
                       : string.Empty;
        }
    }
}
