using System;
using NexusCore.Infrasructure.Adapter.IoC;
using NexusCore.Infrasructure.Infrastructure;

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

        public IDiContainer DiContainer
        {
            get
            {
                if (_diContainer == null)
                    throw new Exception("AutofacFactory has not been intiialized, have you called DiContainerInitialize()");
                return _diContainer;
            }
        }

        public void DiContainerInitialize(IDiContainerFactory diContainerFactory)
        {
            _diContainer = diContainerFactory.Create();
        }


    }
}
