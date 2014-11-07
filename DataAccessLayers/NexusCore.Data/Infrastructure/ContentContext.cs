using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using NexusCore.Common.Data.Entities.Clients;
using NexusCore.Common.Data.Entities.Logs;
using NexusCore.Common.Data.Entities.Membership;
using NexusCore.Common.Data.Entities.Misc;
using NexusCore.Common.Data.Entities.Security;
using NexusCore.Common.Data.Entities.SourceTrees;
using NexusCore.Common.Data.Entities.WebPage;
using NexusCore.Common.Data.Entities.Website;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Data.Infrastructure
{
    public class ContentContext : DbContext, IContentContext
    {

        #region tables

        // Clients
        public IDbSet<Client> Clients { get; set; }
        public IDbSet<ClientDepartment> ClientDepartments { get; set; }

        // Misc
        public IDbSet<FriendlyIdCounter> FriendlyIdCounters { get; set; }
        public IDbSet<Logging> Loggings { get; set; }


        // Membership
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<UserExternalLogin> UserExternalLogins { get; set; }
        //public IDbSet<UserInRole> UsersInRoles { get; set; }

        // Security
        public IDbSet<SourceTreePermission> SourceTreePermissions { get; set; }

        // Source tree
        public IDbSet<ItemInSourceTree> ItemsInSourceTrees { get; set; }
        public IDbSet<SourceTree> SourceTrees { get; set; }

        // WebPage
        public IDbSet<MenuItem> MenuItems { get; set; }
        public IDbSet<PageControl> PageControls { get; set; }
        public IDbSet<PageLink> PageLinks { get; set; }
        public IDbSet<PageSeo> PageSeos { get; set; }
        public IDbSet<WebPage> WebPages { get; set; }

        // Website
        public IDbSet<Domain> Domains { get; set; }
        public IDbSet<Website> WebSites { get; set; }

        #endregion

        public ContentContext() : base("name=NexusCore")
        {
            //Database.SetInitializer<ContentContext>(null);

        }

        #region methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //base.OnModelCreating(modelBuilder);
            foreach (var config in
                Assembly.GetAssembly(typeof (ContentContext))
                    .GetTypes()
                    .Where(
                        a => a.BaseType != null
                             && a.BaseType.IsGenericType
                             && a.BaseType.GetGenericTypeDefinition() == typeof (EntityTypeConfiguration<>)))
            {
                modelBuilder.Configurations.Add((dynamic) Activator.CreateInstance(config));
            }

        }

        public virtual IDbSet<TEntity> CreateSet<TEntity>() where TEntity : Entity
        {
            return base.Set<TEntity>();
        }

        public virtual void Attach<TEntity>(TEntity entity) where TEntity : Entity
        {
            base.Entry(entity).State = EntityState.Unchanged;
        }

        public virtual void SetModified<TEntity>(TEntity entity) where TEntity : Entity
        {
            var entry = base.Entry(entity);

            if (entry.State == EntityState.Deleted)
            {
                var set = CreateSet<TEntity>();
                TEntity attachedEntity = set.Find(entity.Id);
                if (attachedEntity != null)
                    ApplyCurrentValues(attachedEntity, entity);
                else
                    entry.State = EntityState.Modified;
            }

            base.Entry(entity).State = EntityState.Modified;
        }

        public virtual void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : Entity
        {
            base.Entry(original).CurrentValues.SetValues(current);
        }

        public virtual TTarget ExecStoredProcedure<TTarget>(IStoredProcedure model)
            where TTarget : StoredProcedureParsable
        {
            var resultPaser = Activator.CreateInstance<TTarget>();
            return (TTarget) ExecStoredProcedureWithOption(model, resultPaser);

        }

        public virtual void ExecStoredProcedure(IStoredProcedure model)
        {
            ExecStoredProcedureWithOption(model);
        }

        private StoredProcedureParsable ExecStoredProcedureWithOption(IStoredProcedure model,
            StoredProcedureParsable resultPaser = null)
        {
            var cmd = this.Database.Connection.CreateCommand();
            cmd.CommandText = model.StoredProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (var parameter in model.GetParameters())
                cmd.Parameters.Add(new SqlParameter(parameter.Name, parameter.DbType)
                {
                    Value = parameter.Value
                });

            this.Database.Connection.Open();
            if (resultPaser == null)
                cmd.ExecuteNonQuery();
            else
                resultPaser.DbReaderParser(cmd.ExecuteReader());
            try
            {
            }
            catch (Exception ex)
            {
                // TODO add exception later
            }
            finally
            {
                this.Database.Connection.Close();
            }
            return resultPaser;
        }

        #endregion
    }
}
