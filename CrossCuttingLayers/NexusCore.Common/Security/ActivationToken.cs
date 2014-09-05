using System;
using System.Text;
using NexusCore.Infrasructure.Security;

namespace NexusCore.Common.Security
{
    public class ActivationToken: IActivationToken
    {
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }

        public ActivationToken(string email, string passwordHash)
        {
            this.Email = email;
            this.PasswordHash = passwordHash;
        }

        public ActivationToken(string token)
        {
            var parts = Encoding.Default.GetString(Convert.FromBase64String(token)).Split(':');
            if (parts.Length != 2)
                throw new Exception("Invalid token");
            this.Email = parts[0];
            this.PasswordHash = parts[1];
        }

        public string GetToken()
        {
            var token = string.Format("{0}:{1}", Email, PasswordHash);
            return Convert.ToBase64String(Encoding.Default.GetBytes(token));
        }
    }
}
