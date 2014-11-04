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

        public void AddModleError(string key, string errorMessage, Guid clientId = new Guid(), Guid moduleId = new Guid(), TaskCategory category = TaskCategory.None, LogCode logCode = LogCode.None, params object[] args)
        {
            _errors.Add(new SimpleErrorModel
            {
                Key = key,
                ErrorMessage = errorMessage
            });
        }

        public void Clear()
        {
            _errors.Clear();
        }

    }
}
