using System;

namespace NexusCore.Infrasructure.Data
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; }

        #region Public Methods

        /// <summary>
        /// Check if this entity is transient, ie, without identity at this moment
        /// </summary>
        /// <returns>True if entity is transient, else false</returns>
        public bool IsTransient()
        {
            return this.Id == Guid.Empty;
        }

        /// <summary>
        /// Generate identity for this entity
        /// </summary>
        public void GenerateNewIdentity()
        {
            if (IsTransient())
                this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Change current identity for a new non transient identity
        /// </summary>
        /// <param name="identity">the new identity</param>
        public void ChangeCurrentIdentity(Guid identity)
        {
            if (identity != Guid.Empty)
                this.Id = identity;
        }

        #endregion

        #region Overrides Methods

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            var item = (Entity)obj;
            return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Equals(left, null))
                return (Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        #endregion
    }
}
