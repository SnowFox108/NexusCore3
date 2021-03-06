﻿using NexusCore.Common.Adapter.ErrorHandlers;
using NexusCore.Common.Data.Entities.Membership;
using NexusCore.Common.Data.Models.Memberships;
using NexusCore.Common.Helper.Extensions;
using NexusCore.Infrasructure.Models.Enums;
using NexusCore.Infrasructure.Security;
using NexusCore.Infrasructure.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NexusCore.Common.Security
{
    public class CurrentUserProvider: ICurrentUserProvider
    {

        private readonly IAuthenticationManager _authenticationManager;

        public CurrentUserProvider(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }

        public string Email
        {
            get
            {
                if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
                    return Thread.CurrentPrincipal.Identity.Name;
                throw new Exception("User is not login");
            }
        }

        public ICurrentUserModel User
        {
            get
            {
                return ((User)UserIsNotNull(_authenticationManager.GetUserByEmail(Email))).MapTo<CurrentUserModel>();
            }
        }

        public IEnumerable<IRole> Roles
        {
            get
            {
                var user = UserIsNotNull(_authenticationManager.GetUserByEmail(Email));
                return _authenticationManager.GetUserRoles(user.Id);
            }
        }

        private IUser UserIsNotNull(IUser user)
        {
            if (user == null)
            {
                var error = ErrorAdapter.ModelState.AddModelError("", "",
                    logCode: LogCode.CriticalCurrentUserNotLogin);
                throw new Exception(error.ErrorMessage);
            }
            return user;
        }

        public bool IsAdmin
        {
            get
            {
                var adminList = new[] { DefaultUserRoles.Administrators, DefaultUserRoles.SuperModerators};
                return Roles.Any(r => adminList.Contains(r.RoleName));
            }
        }
    }
}
