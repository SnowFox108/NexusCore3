using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using NexusCore.Infrasructure.Data;

namespace NexusCore.MockData.Infrastructure
{

    public class MockDbSet<TEntity> : DbSet<TEntity>, IQueryable, IEnumerable<TEntity> where TEntity : Entity
    {
        private class DataItem
        {
            public EntityState EntityState { get; set; }
            public TEntity Data { get; set; }
        }

        private readonly ObservableCollection<TEntity> _data;
        private readonly Dictionary<Guid, DataItem> _modifyData;
        private readonly IQueryable _query;

        public MockDbSet()
        {
            _data = new ObservableCollection<TEntity>();
            _modifyData = new Dictionary<Guid, DataItem>();
            _query = _data.AsQueryable();
        }

        public override TEntity Add(TEntity entity)
        {
            if (_modifyData.ContainsKey(entity.Id))
                throw new Exception("Item already been Inserted");

            if (_data.Any(item => item.Id == entity.Id))
                throw new Exception("Item already been in data list");

            _modifyData.Add(entity.Id, new DataItem()
            {
                EntityState = EntityState.Added,
                Data = entity
            });

            return entity;
        }

        public override TEntity Remove(TEntity entity)
        {
            if (_modifyData.ContainsKey(entity.Id))
                throw new Exception("Item already been deleted");

            if (_data.All(item => item.Id != entity.Id))
                throw new Exception("Delete item not in data list");

            _modifyData.Add(entity.Id, new DataItem()
            {
                EntityState = EntityState.Deleted,
                Data = entity
            });

            return entity;
        }

        public override TEntity Attach(TEntity entity)
        {
            return entity;
        }

        public void Update(TEntity entity)
        {
            if (_data.All(item => item.Id != entity.Id))
            throw new Exception("Update item not in data list");

            if (_modifyData.ContainsKey(entity.Id))
            throw new Exception("Item already been updated");

            _modifyData.Add(entity.Id, new DataItem()
            {
                EntityState = EntityState.Modified,
                Data = entity
            });
        }

        public void SaveChanges()
        {
            foreach (var item in _modifyData)
            {
                switch (item.Value.EntityState)
                {
                        case EntityState.Added:
                        InsertData(item.Value.Data);
                        break;
                        case EntityState.Modified:
                        UpdateData(item.Value.Data);
                        break;
                        case EntityState.Deleted:
                        DeleteData(item.Value.Data);
                        break;
                }
            }
            _modifyData.Clear();
        }

        private void InsertData(TEntity entity)
        {
            if (_data.Any(item => item.Id == entity.Id))
                throw new Exception("The item already in list.");
            _data.Add(entity);
        }

        private void UpdateData(TEntity entity)
        {
            if (_data.All(item => item.Id != entity.Id))
                throw new Exception("The item want to update is not in list.");
            _data.Remove(entity);
            _data.Add(entity);
        }

        private void DeleteData(TEntity entity)
        {
            if (_data.All(item => item.Id != entity.Id))
                throw new Exception("The item want to delete is not in list.");
            _data.Remove(entity);
        }

        public override TEntity Create()
        {
            return Activator.CreateInstance<TEntity>();
        }

        public override TDerivedEntity Create<TDerivedEntity>()
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public override TEntity Find(params object[] keyValues)
        {
            return !keyValues.Any() ? null : _data.FirstOrDefault(item => item.Id == (Guid) keyValues[0]);

        }

        #region extension

        Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new TestDbAsyncQueryProvider<TEntity>(_query.Provider); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        #endregion

    }

    internal class TestDbAsyncQueryProvider<TEntity> : IDbAsyncQueryProvider
    {
        private readonly IQueryProvider _inner;

        internal TestDbAsyncQueryProvider(IQueryProvider inner)
        {
            _inner = inner;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new TestDbAsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new TestDbAsyncEnumerable<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            return _inner.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        public Task<object> ExecuteAsync(Expression expression, CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute(expression));
        }

        public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute<TResult>(expression));
        }
    }

    internal class TestDbAsyncEnumerable<T> : EnumerableQuery<T>, IDbAsyncEnumerable<T>, IQueryable<T>
    {
        public TestDbAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        { }

        public TestDbAsyncEnumerable(Expression expression)
            : base(expression)
        { }

        public IDbAsyncEnumerator<T> GetAsyncEnumerator()
        {
            return new TestDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator()
        {
            return GetAsyncEnumerator();
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new TestDbAsyncQueryProvider<T>(this); }
        }
    }

    internal class TestDbAsyncEnumerator<T> : IDbAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _inner;

        public TestDbAsyncEnumerator(IEnumerator<T> inner)
        {
            _inner = inner;
        }

        public void Dispose()
        {
            _inner.Dispose();
        }

        public Task<bool> MoveNextAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_inner.MoveNext());
        }

        public T Current
        {
            get { return _inner.Current; }
        }

        object IDbAsyncEnumerator.Current
        {
            get { return Current; }
        }
    }

}
