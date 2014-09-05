using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using NexusCore.Common.Data.Entities.Membership;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Data.Infrastructure
{
    public class ContentContext : DbContext, IContentContext
    {

        #region tables

        // Membership
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<UserExternalLogin> UserExternalLogins { get; set; }
        //public IDbSet<UserInRole> UsersInRoles { get; set; }

        #endregion


        public ContentContext() : base("name=NexusCore")
        {
            //Database.SetInitializer<ContentContext>(null);

        }

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

        public IDbSet<TEntity> CreateSet<TEntity>() where TEntity : Entity
        {
            return base.Set<TEntity>();
        }

        public void Attach<TEntity>(TEntity entity) where TEntity : Entity
        {
            base.Entry(entity).State = EntityState.Unchanged;
        }

        public void SetModified<TEntity>(TEntity entity) where TEntity : Entity
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

        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : Entity
        {
            base.Entry(original).CurrentValues.SetValues(current);
        }

        public TTarget ExecStoredProcedure<TTarget>(IStoredProcedure model) where TTarget : StoredProcedureParsable
        {
            var resultPaser = Activator.CreateInstance<TTarget>();
            return (TTarget)ExecStoredProcedureWithOption(model, resultPaser);

        }

        public void ExecStoredProcedure(IStoredProcedure model)
        {
            ExecStoredProcedureWithOption(model);
        }

        private StoredProcedureParsable ExecStoredProcedureWithOption(IStoredProcedure model, StoredProcedureParsable resultPaser = null)
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


    }
}
