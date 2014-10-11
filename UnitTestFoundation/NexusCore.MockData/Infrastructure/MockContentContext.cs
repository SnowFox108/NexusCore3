using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection;
using NexusCore.Data.Infrastructure;
using NexusCore.Infrasructure.Data;

namespace NexusCore.MockData.Infrastructure
{
    public class MockContentContext : ContentContext
    {

        private readonly Dictionary<string, object> _dbSets; 

        public MockContentContext()
        {
            _dbSets = new Dictionary<string, object>();
        }

        public override int SaveChanges()
        {
            //this.SaveChangesCount++;
            foreach (var dbSet in _dbSets)
            {
                var dbSetType = dbSet.Value.GetType();
                MethodInfo methodInfo = dbSetType.GetMethod("SaveChanges");
                methodInfo.Invoke(dbSet.Value, null);
            }
            return 1;
        }

        public override IDbSet<TEntity> CreateSet<TEntity>()
        {
            var type = typeof(TEntity).Name;

            if (_dbSets.ContainsKey(type))
                return (IDbSet<TEntity>)_dbSets[type];

            var dbSetType = typeof(MockDbSet<>);
            _dbSets.Add(type, Activator.CreateInstance(dbSetType.MakeGenericType(typeof(TEntity))));

            return (IDbSet<TEntity>)_dbSets[type];
        }

        public override void Attach<TEntity>(TEntity entity)
        {
            // change state = EntityState.Unchanged
        }

        public override void SetModified<TEntity>(TEntity entity)
        {
            var type = typeof (TEntity).Name;

            if (!_dbSets.ContainsKey(type))
                throw new Exception("Internal Error DbSet not in list");

            var dbSetType = _dbSets[type].GetType();
            MethodInfo methodInfo = dbSetType.GetMethod("Update");
            methodInfo.Invoke(_dbSets[type], new object[] {entity});
        }

        public override void ApplyCurrentValues<TEntity>(TEntity original, TEntity current)
        {
            // Set orginal value with current value
        }

        /// <summary>
        /// Can not test, mock only
        /// </summary>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public override TTarget ExecStoredProcedure<TTarget>(IStoredProcedure model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Can not test mock only
        /// </summary>
        /// <param name="model"></param>
        public override void ExecStoredProcedure(IStoredProcedure model)
        {
            throw new NotImplementedException();
        }

        
        public void Dispose()
        {
             _dbSets.Clear();
        }
    }
}
