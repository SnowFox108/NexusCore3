using System;
using System.Data.Entity;
using NexusCore.Common.Data.Entities.Clients;
using NexusCore.Common.Data.Entities.Membership;
using NexusCore.Common.Data.Entities.Security;
using NexusCore.Common.Data.Entities.SourceTree;
using NexusCore.Common.Data.Entities.WebPage;
using NexusCore.Common.Data.Entities.Website;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Infrastructure
{
    public interface IContentContext : IDisposable
    {
        #region tables

        // Clients
        IDbSet<Client> Clients { get; set; }
        IDbSet<ClientDepartment> ClientDepartments { get; set; }

        // Membership
        IDbSet<Role> Roles { get; set; }
        IDbSet<User> Users { get; set; }
        IDbSet<UserExternalLogin> UserExternalLogins { get; set; }
        //IDbSet<UserInRole> UsersInRoles { get; set; }

        // Security
        IDbSet<SourceTreePermission> SourceTreePermissions { get; set; }

        // Source tree
        IDbSet<SourceTree> SourceTrees { get; set; }

        // WebPage
        IDbSet<MenuItem> MenuItems { get; set; }
        IDbSet<PageControl> PageControls { get; set; }
        IDbSet<PageLink> PageLinks { get; set; }
        IDbSet<PageSeo> PageSeos { get; set; }
        IDbSet<WebPage> WebPages { get; set; }

        // Website
        IDbSet<Domain> Domains { get; set; }
        IDbSet<WebSite> WebSites { get; set; }

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
