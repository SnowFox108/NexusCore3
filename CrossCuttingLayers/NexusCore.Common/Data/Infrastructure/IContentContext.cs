using System;
using System.Data.Entity;
using NexusCore.Common.Data.Entities.Membership;
using NexusCore.Common.Data.Entities.SourceTree;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Infrastructure
{
    public interface IContentContext : IDisposable
    {
        #region tables

        // Membership
        IDbSet<Role> Roles { get; set; }
        IDbSet<User> Users { get; set; }
        IDbSet<UserExternalLogin> UserExternalLogins { get; set; }
        //IDbSet<UserInRole> UsersInRoles { get; set; }

        // Source tree
        IDbSet<SourceTree> SourceTrees { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// Returns a IDbSet instance for access to entities of the given type in the context, 
        /// the ObjectStateManager, and the underlying store. 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IDbSet<TEntity> CreateSet<TEntity>() where TEntity : Entity;

        /// <summary>
        /// Attach this item into "ObjectStateManager"
        /// </summary>
        /// <typeparam name="TEntity">The type of entity</typeparam>
        /// <param name="entity">The item <</param>
        void Attach<TEntity>(TEntity entity) where TEntity : Entity;

        /// <summary>
        /// Set object as modified
        /// </summary>
        /// <typeparam name="TEntity">The type of entity</typeparam>
        /// <param name="entityToUpdate">The entity item to set as modifed</param>
        void SetModified<TEntity>(TEntity entityToUpdate) where TEntity : Entity;

        /// <summary>
        /// Apply current values in <paramref name="original"/>
        /// </summary>
        /// <typeparam name="TEntity">The type of entity</typeparam>
        /// <param name="original">The original entity</param>
        /// <param name="current">The current entity</param>
        void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : Entity;

        /// <summary>
        /// Execute store procedure with return type from database
        /// </summary>
        /// <typeparam name="TTarget">Delegate result parse</typeparam>
        /// <param name="model">Query model</param>
        /// <returns></returns>
        TTarget ExecStoredProcedure<TTarget>(IStoredProcedure model) where TTarget : StoredProcedureParsable;

        /// <summary>
        /// Execute store procedure type from database
        /// </summary>
        /// <param name="model">Query model</param>
        void ExecStoredProcedure(IStoredProcedure model);

        /// <summary>
        /// Commit save changes
        /// </summary>
        int SaveChanges();

        #endregion
    }
}
