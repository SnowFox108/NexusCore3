using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexusCore.Common.Infrastructure;
using NexusCore.Common.Services.MembershipServices;
using NexusCore.Infrasructure.Model.Enums;

namespace ClientTest
{
    public class GetUserModel
    {
        public GetUserModel()
        {
            var users = EngineContext.Instance.DiContainer.GetInstance<IUserPrimitive>();
            var result = users.GetUsers("Email", SortDirection.Desc, 3,1);

            foreach (var user in result)
            {
                Console.WriteLine("FirstName: {0} \t LastName: {1} \t Email: {2}", user.FirstName, user.LastName,
                    user.Email);
            }

        }
    }
}
