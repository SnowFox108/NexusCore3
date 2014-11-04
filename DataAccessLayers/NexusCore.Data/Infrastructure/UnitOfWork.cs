using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Infrasructure.Data;
using NexusCore.Infrasructure.Security;

namespace NexusCore.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IContentContext _contentContext;
        private readonly ICurrentUserProvider _currentUserProvider;
        private bool _disposed;
        private Dictionary<string, object> _repositories;

        public IContentContext ContentContext
        {
            get { return _contentContext; }
        }

        public UnitOfWork(ICurrentUserProvider currentUserProvider): this(new ContentContext(), currentUserProvider)
        {            
        }

        public UnitOfWork(IContentContext contentContext, ICurrentUserProvider currentUserProvider)
        {
            _contentContext = contentContext ?? new ContentContext();
            _currentUserProvider = currentUserProvider;
        }

        public int SaveChanges()
        {
            try
            {
                return _contentContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw new DbEntityValidationException(
                    ex.EntityValidationErrors.Where(e => !e.IsValid)
                        .Select(
                            e =>
                                e.ValidationErrors.Select(
                                    v => string.Format("{0} - {1}", v.PropertyName, v.ErrorMessage))
                                    .Aggregate((acc, c) => string.Format("{0}\n{1}", acc, c)))
                        .Aggregate(string.Concat),
                    ex);
            }
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : Entity 
        {
            if (_repositories == null)
                _repositories = new Dictionary<string, object>();

            var type = typeof (TEntity).Name;

            if (_repositories.ContainsKey(type))
                return (IRepository<TEntity>) _repositories[type];

            var repositoryType = typeof (Repository<>);
            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _contentContext, _currentUserProvider));

            return (IRepository<TEntity>) _repositories[type];
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                _contentContext.Dispose();
            _disposed = true;
        }
    }
}
