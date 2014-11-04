using NexusCore.Infrasructure.Adapter.ErrorHandlers;

namespace NexusCore.Common.Adapter.ErrorHandlers
{
    public class ErrorAdapter
    {
        private static readonly IErrorHandlerFactory ErrorHandlerFactory;

        static ErrorAdapter()
        {
            ErrorHandlerFactory = new SimpleErrorHandlerFactory();
        }

        public static IErrorHandler ModelState
        {
            get { return ErrorHandlerFactory.Create(); }
        }
    }
}
