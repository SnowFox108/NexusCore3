using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection;
using NexusCore.Common.Data.Entities.Membership;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Infrasructure.Data;

namespace NexusCore.MockData.Infrastructure
{
    public class MockContentContext : IContentContext
    {

        #region tables

        // Membership
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<UserExternalLogin> UserExternalLogins { get; set; }

        #endregion

        private Dictionary<string, object> _dbSets; 

        public MockContentContext()
        {
            _dbSets = new Dictionary<string, object>();
        }

        public int SaveChanges()
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

        public IDbSet<TEntity> CreateSet<TEntity>() where TEntity : Entity
        {
            var type = typeof(TEntity).Name;

            if (_dbSets.ContainsKey(type))
                return (IDbSet<TEntity>)_dbSets[type];

            var dbSetType = typeof(MockDbSet<>);
            _dbSets.Add(type, Activator.CreateInstance(dbSetType.MakeGenericType(typeof(TEntity))));

            return (IDbSet<TEntity>)_dbSets[type];
        }

        public void Attach<TEntity>(TEntity entity) where TEntity : Entity
        {
            // change state = EntityState.Unchanged
        }

        public void SetModified<TEntity>(TEntity entity) where TEntity : Entity
        {
            var type = typeof (TEntity).Name;

            if (!_dbSets.ContainsKey(type))
                throw new Exception("Internal Error DbSet not in list");

            var dbSetType = _dbSets[type].GetType();
            MethodInfo methodInfo = dbSetType.GetMethod("Update");
            methodInfo.Invoke(_dbSets[type], new object[] {entity});
        }

        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : Entity
        {
            // Set orginal value with current value
        }

        /// <summary>
        /// Can not test, mock only
        /// </summary>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public TTarget ExecStoredProcedure<TTarget>(IStoredProcedure model) where TTarget : StoredProcedureParsable
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Can not test mock only
        /// </summary>
        /// <param name="model"></param>
        public void ExecStoredProcedure(IStoredProcedure model)
        {
            throw new NotImplementedException();
        }

        
        public void Dispose()
        {
             _dbSets.Clear();
        }
    }
}
