using System;

namespace Distrib.Core.Domain
{
    /// <summary>
    /// Standard abstraction of application entities.
    /// </summary>
    public abstract class EntityBase
    {
        #region Properties

        /// <summary>
        /// Gets entity Id.
        /// </summary>
        public Guid Id { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBase"/> class.
        /// </summary>
        /// <param name="id">Entity id, a random value will be generated if it is null.</param>
        protected EntityBase(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
        }

        #endregion

        #region Object

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            var compareTo = obj as EntityBase;

            if (ReferenceEquals(this, compareTo))
            {
                return true;
            }

            if (ReferenceEquals(null, compareTo))
            {
                return false;
            }

            return Id.Equals(compareTo.Id);
        }

        /// <summary>
        /// Check if the entities are equal.
        /// </summary>
        /// <param name="a">Entity a.</param>
        /// <param name="b">Entity b.</param>
        /// <returns>True if the entities are equal, false otherwise.</returns>
        public static bool operator ==(EntityBase a, EntityBase b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        /// <summary>
        /// Check if the entities are not equal.
        /// </summary>
        /// <param name="a">Entity a.</param>
        /// <param name="b">Entity b.</param>
        /// <returns>True if the entities are not equal, false otherwise.</returns>
        public static bool operator !=(EntityBase a, EntityBase b)
        {
            return !(a == b);
        }

        /// <inheritdoc/>
        public override int GetHashCode() =>
            (GetType().GetHashCode() * 907) + Id.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() =>
            $"{GetType().Name} [Id={Id}]";

        #endregion
    }
}
