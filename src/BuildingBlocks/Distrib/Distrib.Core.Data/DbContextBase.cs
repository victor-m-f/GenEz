using Microsoft.EntityFrameworkCore;

namespace Distrib.Core.Data
{
    /// <summary>
    /// Base entity framework context to be used by all other contexts.
    /// </summary>
    /// <typeparam name="TDbContext">The type that is inheriting this class.</typeparam>
    public abstract class DbContextBase<TDbContext> : DbContext
        where TDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextBase{TDbContext}"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        protected DbContextBase(DbContextOptions<TDbContext> options)
            : base(options)
        {
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            _ = modelBuilder.ApplyConfigurationsFromAssembly(typeof(TDbContext).Assembly);
    }
}
