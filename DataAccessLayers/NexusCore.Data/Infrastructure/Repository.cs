using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Helper;
using NexusCore.Infrasructure.Data;
using NexusCore.Infrasructure.Security;

namespace NexusCore.Data.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: Entity 
    {
        private readonly IContentContext _contentContext;

        public IContentContext ContentContext
        {
            get { return _contentContext; }
        }
        
        IDbSet<TEntity> GetDbSet()
        {
            return _contentContext.CreateSet<TEntity>();
        }

        private readonly ICurrentUserProvider _userProvider;

        public Repository(IContentContext contentContext, ICurrentUserProvider userProvider)
        {
            if (contentContext == null)
                throw new ArgumentNullException("missing dbContent");

            _contentContext = contentContext;
            _userProvider = userProvider;
        }

        public void Insert(params TEntity[] items)
        {
            foreach (var item in items)
            {
                if (item != null)
                {
                    // generate new Id
                    item.GenerateNewIdentity();
                    // check trackable item for create
                    if (item.GetType().GetInterfaces().Contains(typeof (ITrackable)))
                    {
                        var tracker = (ITrackable) item;
                        if (tracker.CreatedDate == default(DateTime))
                            tracker.CreatedDate = DateFormater.DateTimeNow;
                        if (tracker.CreatedBy == default(Guid))
                            tracker.CreatedBy = GetCurrentUserId();
                    }

                    GetDbSet().Add(item);
                }
                else
                {
                    //TODO create null error log later
                }
            }
        }

        public void Delete(params object[] id)
        {
            Delete(GetDbSet().Find(id));
        }

        public void Delete(TEntity item)
        {
            if (item != null)
            {
                _contentContext.Attach(item);
                GetDbSet().Remove(item);
            }
            else
            {
                //TODO create null error log
            }
        }

        public void Update(TEntity item)
        {
            if (item != null)
            {
                _contentContext.SetModified(item);

                // check trackable item for create
                if (item.GetType().GetInterfaces().Contains(typeof (ITrackable)))
                {
                    var tracker = (ITrackable) item;
                    if (tracker.UpdatedDate == default(DateTime))
                        tracker.UpdatedDate = DateFormater.DateTimeNow;
                    if (tracker.UpdatedBy == default(Guid))
                        tracker.UpdatedBy = GetCurrentUserId();
                }
            }
            else
            {
                //TODO create null error log
            }
        }

        public void TrackItem(TEntity item)
        {
            if (item != null)
                _contentContext.Attach(item);
            else
            {
                //TODO create null error log
            }
        }

        public void Merge(TEntity persisted, TEntity current)
        {
            _contentContext.ApplyCurrentValues(persisted, current);
        }

        public TEntity GetById(params object[] id)
        {
            if (id != null)
                return GetDbSet().Find(id);
            return null;
        }

        /// <summary>
        /// Get list of result by query
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="pageNumber">page number: only works when orderBy is given</param>
        /// <param name="pageSize">page size: only works when orderBy is given</param>
        /// <returns></returns>
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int pageNumber = -1,
            int pageSize = 10)
        {
            IQueryable<TEntity> query = GetDbSet();

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
            {
                query = orderBy(query);
                if (pageNumber > 0)
                    query = query.Skip((pageNumber - 1)*pageSize).Take(pageSize);
            }

            query = includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
           
#if DEBUG
            Debug.WriteLine("Query Linq: " + query);
#endif
            return query;
        }

        /// <summary>
        /// Get list of result by sepcification
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="pageNumber">page number: only works when orderBy is given</param>
        /// <param name="pageSize">page size: only works when orderBy is given</param>
        /// <returns></returns>
        public IQueryable<TEntity> Get(ISpecification<TEntity> specification, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int pageNumber = -1,
            int pageSize = 10)
        {
            IQueryable<TEntity> query = GetDbSet();

            if (specification != null)
                query = query.Where(specification.SatisfiedBy());

            if (orderBy != null)
            {
                query = orderBy(query);
                if (pageNumber > 0)
                    query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            }

            query = includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

#if DEBUG
            Debug.WriteLine("Specification: " + query);
#endif
            return query;
        }

        public void Dispose()
        {
            if (_contentContext != null)
                _contentContext.Dispose();
        }

        private Guid GetCurrentUserId()
        {
            if (_userProvider == null)
                return default(Guid);

            var user = _contentContext.Users.SingleOrDefault(u => u.Email == _userProvider.Email);
            return user != null ? user.Id : default(Guid);
        }
    }
}
