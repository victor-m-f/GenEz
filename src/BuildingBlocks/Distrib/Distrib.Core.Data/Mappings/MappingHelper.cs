using Distrib.Core.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq.Expressions;

namespace Distrib.Core.Data.Mappings
{
    /// <summary>
    /// Contain helper methods to map entities and value objects.
    /// </summary>
    public static class MappingHelper
    {
        /// <summary>
        /// Adds the default mapping to the value object <see cref="Image"/>.
        /// </summary>
        /// <typeparam name="T">The entity type to be mapped.</typeparam>
        /// <returns>Returns the builder with image configured for the T entity.</returns>
        public static Action<OwnedNavigationBuilder<T, Image>> ImageMap<T>()
            where T : class
        {
            const string className = nameof(Image);
            return builder =>
            {
                _ = builder.Property(x => x.Id).IsGuid().HasColumnName(className + nameof(Image.Id));
                _ = builder.Property(x => x.Url).IsVarChar(160).HasColumnName(className + nameof(Image.Url));
                _ = builder.Property(x => x.Folder).IsVarChar(40).HasColumnName(className + nameof(Image.Folder));
            };
        }

        /// <summary>
        /// Adds the default mapping to the value object <see cref="Email"/>.
        /// </summary>
        /// <remarks>
        /// The property in the migration file will continue to be nullable: true even if emailAddressIsRequired is set to true.
        /// </remarks>
        /// <typeparam name="T">The entity type to be mapped.</typeparam>
        /// <param name="emailAddressIsRequired">Defines whether the email address can be null.</param>
        /// <param name="emailAddressMustBeUnique">Defines whether the email address must be unique.</param>
        /// <example>
        /// b.OwnsOne(x => x.Email, MappingHelper.EmailMap&lt;T>(true)).
        /// </example>
        /// <returns>Returns the builder with email configured for the T entity.</returns>
        public static Action<OwnedNavigationBuilder<T, Email>> EmailMap<T>(bool emailAddressIsRequired = false, bool emailAddressMustBeUnique = false)
            where T : class
        {
            const string className = nameof(Email);
            return builder =>
            {
                var propBuilder = builder.Property(x => x.Address).IsVarChar(160).HasColumnName(className + nameof(Email.Address));
                if (emailAddressIsRequired)
                {
                    _ = propBuilder.IsRequired();
                }

                if (emailAddressMustBeUnique)
                {
                    _ = builder.HasIndex(nameof(Email.Address)).IsUnique();
                }
            };
        }

        /// <summary>
        /// Configures a <see cref="Guid" /> as the primary key of the table.
        /// </summary>
        /// <typeparam name="T">The entity type to be mapped.</typeparam>
        /// <param name="typeBuilder">The entity type builder of the entity to be mapped.</param>
        /// <param name="expression">Expression indicating which property will be mapped as the primary key.</param>
        /// <returns>A entity type builder to continue being configured.</returns>
        public static EntityTypeBuilder<T> HasGuidPk<T>(this EntityTypeBuilder<T> typeBuilder, Expression<Func<T, object>> expression)
            where T : class
        {
            _ = typeBuilder.HasIndex(expression);
            _ = typeBuilder.Property(expression);

            return typeBuilder;
        }

        /// <summary>
        /// Configures the data type as varchar(maxLength) in a relational database.
        /// </summary>
        /// <param name="propBuilder">The prop builder of a <see cref="string"/>.</param>
        /// <param name="maxLength">Max length of the property in the context.</param>
        /// <param name="isRequired">A value indicating whether the property is required.</param>
        /// <returns>A property builder to continue being configured.</returns>
        public static PropertyBuilder<string> IsVarChar(this PropertyBuilder<string> propBuilder, int maxLength, bool isRequired = false)
        {
            if (isRequired)
            {
                _ = propBuilder.IsRequired();
            }

            _ = propBuilder.HasColumnType($"varchar({maxLength})");

            return propBuilder;
        }

        /// <summary>
        /// Configures the data type as char(maxLength) in a relational database.
        /// </summary>
        /// <param name="propBuilder">The prop builder of a <see cref="string"/>.</param>
        /// <param name="maxLength">Max length of the property in the context.</param>
        /// <param name="isRequired">A value indicating whether the property is required.</param>
        /// <returns>A property builder to continue being configured.</returns>
        public static PropertyBuilder<string> IsChar(this PropertyBuilder<string> propBuilder, int maxLength, bool isRequired = false)
        {
            if (isRequired)
            {
                _ = propBuilder.IsRequired();
            }

            _ = propBuilder.HasColumnType($"char({maxLength})");

            return propBuilder;
        }

        /// <summary>
        /// Configures the data type as datetime in a relational database.
        /// </summary>
        /// <param name="propBuilder">The prop builder of a <see cref="DateTime"/>.</param>
        /// <returns>A property builder to continue being configured.</returns>
        public static PropertyBuilder<DateTime> IsDateTime(this PropertyBuilder<DateTime> propBuilder)
        {
            _ = propBuilder.IsRequired();
            _ = propBuilder.HasColumnType("datetime");
            return propBuilder;
        }

        /// <summary>
        /// Configures the data type as datetime in a relational database.
        /// </summary>
        /// <param name="propBuilder">The prop builder of a <see cref="Nullable{DateTime}"/>.</param>
        /// <returns>A property builder to continue being configured.</returns>
        public static PropertyBuilder<DateTime?> IsDateTime(this PropertyBuilder<DateTime?> propBuilder)
        {
            _ = propBuilder.HasColumnType("datetime");
            return propBuilder;
        }

        /// <summary>
        /// Configures the data type as guid in a relational database.
        /// </summary>
        /// <param name="propBuilder">The prop builder of a <see cref="Guid"/>.</param>
        /// <returns>A property builder to continue being configured.</returns>
        public static PropertyBuilder<Guid> IsGuid(this PropertyBuilder<Guid> propBuilder)
        {
            _ = propBuilder.HasColumnType("uniqueidentifier");
            return propBuilder;
        }

        /// <summary>
        /// Configures the decimal type as decimal in a relational database.
        /// </summary>
        /// <param name="propBuilder">The prop builder of a <see cref="decimal"/>.</param>
        /// <returns>A property builder to continue being configured.</returns>
        public static PropertyBuilder<decimal> IsDecimal(this PropertyBuilder<decimal> propBuilder)
        {
            _ = propBuilder.IsRequired();
            _ = propBuilder.HasColumnType("decimal(12,2)");
            return propBuilder;
        }

        /// <summary>
        /// Configures the decimal type as decimal in a relational database.
        /// </summary>
        /// <param name="propBuilder">The prop builder of a <see cref="Nullable{Decimal}"/>.</param>
        /// <returns>A property builder to continue being configured.</returns>
        public static PropertyBuilder<decimal?> IsDecimal(this PropertyBuilder<decimal?> propBuilder)
        {
            _ = propBuilder.HasColumnType("decimal(12,2)");
            return propBuilder;
        }
    }
}
