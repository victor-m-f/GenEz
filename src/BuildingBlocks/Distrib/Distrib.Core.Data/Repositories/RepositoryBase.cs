using AutoMapper;
using Distrib.Core.Domain;
using Distrib.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distrib.Core.Data.Repositories
{
    /// <summary>
    /// Base repository to be used by all other repositories, implements methods that are used commonly.
    /// </summary>
    /// <typeparam name="TDbContext">Type of <see cref="DbContext"/> that this repository and its implementations will represent.</typeparam>
    public abstract class RepositoryBase<TDbContext> : IRepository
        where TDbContext : DbContext
    {
        #region Properties

        /// <summary>
        /// Gets the <see cref="DbContext"/> used by this repository.
        /// </summary>
        public TDbContext Context { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T}"/> class using the specified <see cref="DbContext"/>.
        /// </summary>
        /// <param name="context">The <see cref="DbContext"/> this repository will represent.</param>
        protected RepositoryBase(TDbContext context)
        {
            Context = context;
        }

        #endregion

        /// <summary>
        /// Gets an entity by its Id.
        /// </summary>
        /// <typeparam name="TEntity">The entity type. Must be included as a DbSet in the DbContext.</typeparam>
        /// <param name="id">The <see cref="Guid"/> Id of the entity.</param>
        /// <returns>The entity with the given Id.</returns>
        public async Task<TEntity> GetByIdAsync<TEntity>(Guid? id)
            where TEntity : class
        {
            return id is Guid normalId ? await Context.Set<TEntity>().FindAsync(normalId) : null;
        }

        /// <summary>
        /// Get entities by their ids.
        /// </summary>
        /// <typeparam name="TEntity">The entities type. Must be included as a DbSet in the DbContext.</typeparam>
        /// <param name="ids">The <see cref="Guid"/> Ids of the entities.</param>
        /// <returns>A collection of entities with the given ids.</returns>
        public async Task<IEnumerable<TEntity>> GetByIdsAsync<TEntity>(params Guid[] ids)
            where TEntity : EntityBase
        {
            if (!ids.Any())
            {
                return Enumerable.Empty<TEntity>();
            }

            return await Context.Set<TEntity>().Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        /// <summary>
        /// Begin tracking the given entity to be commited later.
        /// </summary>
        /// <typeparam name="TEntity">The entity type. Must be included as a DbSet in the DbContext.</typeparam>
        /// <param name="entity">The entity to be created.</param>
        public void Create<TEntity>(TEntity entity)
            where TEntity : class
        {
            if (entity == null)
            {
                return;
            }

            _ = Context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Begin tracking the changes to the given entity to be commited later.
        /// </summary>
        /// <typeparam name="TEntity">The entity type. Must be included as a DbSet in the DbContext.</typeparam>
        /// <param name="entity">The entity to be updated.</param>
        public void Update<TEntity>(TEntity entity)
            where TEntity : class =>
            _ = Context.Set<TEntity>().Update(entity);

        /// <summary>
        /// Begin tracking the entity as deleted to be commited later.
        /// </summary>
        /// <typeparam name="TEntity">The entity type. Must be included as a DbSet in the DbContext.</typeparam>
        /// <param name="entity">The entity to be deleted.</param>
        public void Delete<TEntity>(TEntity entity)
            where TEntity : class =>
            _ = Context.Set<TEntity>().Remove(entity);

        /// <summary>
        /// Asynchronously applies any pending migration for the context to the database.
        /// </summary>
        /// <returns>A task that represents the asynchronous migration operation.</returns>
        public async Task UpdateDatabaseAsync() => await Context.Database.MigrateAsync();

        /// <summary>
        /// Commits all changes made by this repository to the database.
        /// </summary>
        /// <returns>A task that represents the asynchronous commit operation.</returns>
        public async Task<bool> CommitAsync()
        {
            foreach (var entry in Context.ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("CreationDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreationDate").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreationDate").IsModified = false;
                }
            }

            return await Context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Releases the allocated resources for this repository.
        /// </summary>
        public void Dispose() => Context.Dispose();
    }
}
