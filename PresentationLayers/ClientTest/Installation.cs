using System;
using NexusCore.Common.Adapter.ErrorHandlers;
using NexusCore.Common.Adapter.Logs;
using NexusCore.Common.Data.Models.Clients;
using NexusCore.Common.Data.Models.Installation;
using NexusCore.Common.Infrastructure;
using NexusCore.Common.Services;
using NexusCore.Common.Services.InstallationServices;

namespace ClientTest
{
    public class Installation
    {
        public Installation()
        {
            var install = EngineContext.Instance.DiContainer.GetInstance<IInstallationService>();
            var friendlyId = EngineContext.Instance.DiContainer.GetInstance<IPrimitiveServices>();

                install.Setup(new InstallationModel
                {
                    Administrator = new InstallationAdministratorModel
                    {
                        Title = "Mr",
                        Email = "mike.zhang@admin.com",
                        FirstName = "Mike",
                        LastName = "Zhang",
                        PhoneNumber = ""
                    },
                    Client = new InstallationClientModel()
                    {
                        Client = new ClientModel()
                        {
                            FriendlyId = friendlyId.FriendlyIdPrimitive.GetFriendlyId("CL"),
                            Name = "Default Client",
                            Description = "Default Installation",
                            LogoUrl = ""
                        },
                        ClientDepartment = new ClientDepartmentModel()
                        {
                            Name = "Main Department",
                            Description = "Main Department",
                            ContactTitle = "Mr",
                            ContactFirstName = "Mike",
                            ContactLastName = "Zhang",
                            ContactPhone = "",
                            ContactEmail = "mike.zhang@admin.com",
                            AddressLine1 = "",
                            PostCode = ""
                        }
                    }
                });

            if (ErrorAdapter.ModelState.IsValid)
                LoggerAdapter.Logger.Debug("Installation Completed");
            else
            {
                foreach (var error in ErrorAdapter.ModelState.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            //{
            //    var error = string.Format("Error: {0}", ex.Message);
            //    LoggerAdapter.Logger.Debug(error);
            //    Console.WriteLine(error);
            //}
        }
    }
}
