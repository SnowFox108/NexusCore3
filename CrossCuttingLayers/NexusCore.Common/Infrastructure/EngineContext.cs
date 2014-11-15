using System;
using NexusCore.Common.Adapter.ErrorHandlers;
using NexusCore.Infrasructure.Adapter.IoC;
using NexusCore.Infrasructure.Infrastructure;
using NexusCore.Infrasructure.Models.Enums;
using NexusCore.Infrasructure.Security;

namespace NexusCore.Common.Infrastructure
{
    public class EngineContext : IEngine
    {
        private static IEngine _instance;

        public static IEngine Instance
        {
            get { return _instance ?? (_instance = new EngineContext()); }
        }

        private IDiContainer _diContainer;
        private ICurrentUserProvider _currentUserProvider;

        public IDiContainer DiContainer
        {
            get
            {
                if (_diContainer == null)
                {
                    var error = ErrorAdapter.ModelState.AddModleError("", "",
                        logCode: LogCode.CriticalEngineDiContainerNotInitialized);
                    throw new Exception(error.ErrorMessage);                    
                }
                return _diContainer;
            }
        }

        public ICurrentUserProvider CurrentUser
        {
            get
            {
                if (_currentUserProvider == null)
                {
                    var error = ErrorAdapter.ModelState.AddModleError("", "",
                        logCode: LogCode.CriticalEngineCurrentUserProviderNotInitialized);
                    throw new Exception(error.ErrorMessage);
                }
                return _currentUserProvider;
            }
        }

        public void Initialize(IDiContainerFactory diContainerFactory)
        {
            DiContainerInitialize(diContainerFactory);
            CurrentUserProviderInitialize();
        }

        private void DiContainerInitialize(IDiContainerFactory diContainerFactory)
        {
            _diContainer = diContainerFactory.Create();            
        }

        private void CurrentUserProviderInitialize()
        {
            _currentUserProvider = _diContainer.GetInstance<ICurrentUserProvider>();
        }



    }
}
