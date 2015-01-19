﻿using NexusCore.Common.Infrastructure;
using NexusCore.Common.Services;
using NexusCore.Common.Services.InstallationServices;
using NexusCore.Common.Services.MembershipServices;
using NexusCore.Common.Services.SourceTreeServices;


namespace NexusCore.Core.Services.Infrastructure
{
    public class ComponentServices : IComponentServices
    {

        public IInstallationService InstallationService { get; set; }
        public IMembershipService MembershipService { get; set; }
        public ISourceTreeService SourceTreeService { get; set; }
    }
}