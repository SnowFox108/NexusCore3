using System;
using NexusCore.Common.Data.Models.Installation;
using NexusCore.Common.Infrastructure;
using NexusCore.Common.Services.Installation;

namespace ClientTest
{
    public class Installation
    {
        public Installation()
        {
            var install = EngineContext.Instance.DiContainer.GetInstance<IInstallationService>();

            try
            {
                install.Setup(new InstallationModel
                {
                    Administrator = new InstallationAdministratorModel
                    {
                        Title = "Mr",
                        UserName = "Mike Zhang",
                        Email = "mike.zhang@admin.com",
                        FirstName = "Mike",
                        LastName = "Zhang",
                        PhoneNumber = ""
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }
    }
}
