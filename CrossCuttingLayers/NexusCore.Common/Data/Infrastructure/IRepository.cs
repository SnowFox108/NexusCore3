using System;
using System.Linq;
using System.Linq.Expressions;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Infrastructure
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        /// <summary>
        /// Get the unit of work in this repository
        /// </summary>
        IContentContext ContentContext { get; }

        /// <summary>
        /// Add item into repository
        /// </summary>
        /// <param name="item">Item to add to repository</param>
        void Insert(params TEntity[] item);

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="id">Item to delete</param>
        void Delete(params object[] id);

        /// <summary>
        /// Delete item 
        /// </summary>
        /// <param name="item">Item to delete</param>
        void Delete(TEntity item);

        /// <summary>
        /// Set item as modified
        /// </summary>
        /// <param name="item">Item to modify</param>
        void Update(TEntity item);

        /// <summary>
        ///Track entity into this repository, really in UnitOfWork. 
        ///In EF this can be done with Attach and with Update in NH
        /// </summary>
        /// <param name="item">Item to attach</param>
        void TrackItem(TEntity item);

        /// <summary>
        /// Sets modified entity into the repository. 
        /// When calling Commit() method in UnitOfWork 
        /// these changes will be saved into the storage
        /// </summary>
        /// <param name="persisted">The persisted item</param>
        /// <param name="current">The current item</param>
        void Merge(TEntity persisted, TEntity current);

        /// <summary>
        /// Get element by entity key
        /// </summary>
        /// <param name="id">Entity key value</param>
        /// <returns></returns>
        TEntity GetById(params object[] id);

        /// <summary>
        /// Get all elements of type TEntity in repository
        /// </summary>
        /// <returns>List of selected elements</returns>
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            int pageNumber = -1,
            int pageSize = 10);

        /// <summary>
        /// Get all elements of type TEntity in repository who match specification
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IQueryable<TEntity> Get(ISpecification<TEntity> specification, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int pageNumber = -1,
            int pageSize = 10);

    }
}
