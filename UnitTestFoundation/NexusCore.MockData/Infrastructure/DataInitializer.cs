using System;
using NexusCore.Common.Data.Infrastructure;

namespace NexusCore.MockData.Infrastructure
{
    public class DataInitializer
    {
        private readonly IUnitOfWork _unitOfWork;

        #region Initializer Data
        //private readonly Guid _defaultUserId = new Guid("7EDD0892-3F14-4B77-9B7C-37324E9A3B8E");
        #endregion

        public DataInitializer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Setup()
        {
            DateTime dtNow = DateTime.Now;

            _unitOfWork.SaveChanges();
        }

        public void Reset()
        {

        }
    }
}
