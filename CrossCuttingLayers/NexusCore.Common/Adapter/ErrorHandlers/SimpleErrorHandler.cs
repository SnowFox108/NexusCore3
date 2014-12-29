using System.Globalization;
using NexusCore.Common.Adapter.Language;
using NexusCore.Common.Adapter.Logs;
using NexusCore.Infrasructure.Adapter.ErrorHandlers;
using NexusCore.Infrasructure.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace NexusCore.Common.Adapter.ErrorHandlers
{
    [DataContract]
    public class SimpleErrorHandler : IErrorHandler
    {
        private readonly List<IErrorModel> _errors;

        public IEnumerable<IErrorModel> Errors
        {
            get { return _errors; }
        }

        public SimpleErrorHandler()
        {
            _errors = new List<IErrorModel>();
        }

        public bool IsValid
        {
            get { return !_errors.Any(); }
        }

        public IErrorModel AddModelError(string key, string errorMessage, Guid clientId = new Guid(),
            Guid moduleId = new Guid(), LogCode logCode = LogCode.None, params object[] args)
        {
            var errorModel = new SimpleErrorModel
            {
                Key = key,
                ErrorMessage = string.IsNullOrEmpty(errorMessage) ? LogCodeText.GetString(logCode) : errorMessage
            };
            _errors.Add(errorModel);

            // Check if this error need to be log
            if (logCode.Value().IsLogged)
                LoggerAdapter.Logger.Log(LogCodeText.GetString(logCode), clientId, moduleId, logCode.Value().Category,
                    logCode.Value().Level, logCode, args);
            
            return errorModel;
        }

        public IErrorModel AddModelError(Guid clientId = new Guid(), Guid moduleId = new Guid(), LogCode logCode = LogCode.None, params object[] args)
        {
            return AddModelError("", "", clientId, moduleId, logCode, args);
        }

        public void Clear()
        {
            _errors.Clear();
        }



    }
}
