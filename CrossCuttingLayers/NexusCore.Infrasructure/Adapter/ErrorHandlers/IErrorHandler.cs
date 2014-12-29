using System;
using System.Collections.Generic;
using NexusCore.Infrasructure.Models.Enums;

namespace NexusCore.Infrasructure.Adapter.ErrorHandlers
{
    public interface IErrorHandler
    {

        IEnumerable<IErrorModel> Errors { get; }

        bool IsValid { get; }

        IErrorModel AddModelError(string key, string errorMessage, Guid clientId = new Guid(), Guid moduleId = new Guid(),
            LogCode logCode = LogCode.None, params object[] args);

        IErrorModel AddModelError( Guid clientId = new Guid(), Guid moduleId = new Guid(), LogCode logCode = LogCode.None, params object[] args);

        void Clear();
    }
}
