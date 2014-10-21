using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexusCore.Common.Data.Entities.Clients;
using NexusCore.Common.Data.Entities.Membership;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.Installation;
using NexusCore.Common.Infrastructure;
using NexusCore.Common.Security;
using NexusCore.Common.Services.Installation;
using NexusCore.Core.Services;
using NexusCore.Core.Services.InstallationComponent;
using NexusCore.Data.Infrastructure;

namespace ClientTest
{
    public class Installation
    {
        public Installation()
        {
            var install = EngineContext.Instance.DiContainer.GetInstance<IInstallationService>();

            var unitOfWork = EngineContext.Instance.DiContainer.GetInstance<IUnitOfWork>();

            var result = unitOfWork.Repository<Client>().Get();


            install.Setup(new InstallationModel()
            {
                Administrator = new InstallationAdministratorModel()
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
    }
}
