using NexusCore.Infrasructure.Adapter.ErrorHandlers;

namespace NexusCore.Common.Adapter.ErrorHandlers
{
    public class SimpleErrorHandlerFactory : IErrorHandlerFactory
    {
        private readonly IErrorHandler _errorHandler;

        public SimpleErrorHandlerFactory()
        {
            if (_errorHandler == null)
                _errorHandler = new SimpleErrorHandler();
        }

        public IErrorHandler Create()
        {
            return _errorHandler;
        }
    }
}
