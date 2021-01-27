using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Distrib.Core.Domain.Repositories
{
    /// <summary>
    /// Base repository interface to be used by all other repositories.
    /// </summary>
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// Gets an entity by its Id.
        /// </summary>
        /// <typeparam name="TEntity">The entity type. Must be included as a DbSet in the DbContext.</typeparam>
        /// <param name="id">The <see cref="Guid"/> Id of the entity.</param>
        /// <returns>The entity with the given Id.</returns>
        Task<TEntity> GetByIdAsync<TEntity>(Guid? id)
            where TEntity : class;

        /// <summary>
        /// Get entities by their ids.
        /// </summary>
        /// <typeparam name="TEntity">The entities type. Must be included as a DbSet in the DbContext.</typeparam>
        /// <param name="ids">The <see cref="Guid"/> Ids of the entities.</param>
        /// <returns>A collection of entities with the given ids.</returns>
        Task<IEnumerable<TEntity>> GetByIdsAsync<TEntity>(params Guid[] ids)
            where TEntity : EntityBase;

        /// <summary>
        /// Begin tracking the given entity to be commited later.
        /// </summary>
        /// <typeparam name="TEntity">The entity type. Must be included as a DbSet in the DbContext.</typeparam>
        /// <param name="entity">The entity to be created.</param>
        void Create<TEntity>(TEntity entity)
            where TEntity : class;

        /// <summary>
        /// Begin tracking the changes to the given entity to be commited later.
        /// </summary>
        /// <typeparam name="TEntity">The entity type. Must be included as a DbSet in the DbContext.</typeparam>
        /// <param name="entity">The entity to be updated.</param>
        void Update<TEntity>(TEntity entity)
            where TEntity : class;

        /// <summary>
        /// Begin tracking the entity as deleted to be commited later.
        /// </summary>
        /// <typeparam name="TEntity">The entity type. Must be included as a DbSet in the DbContext.</typeparam>
        /// <param name="entity">The entity to be deleted.</param>
        void Delete<TEntity>(TEntity entity)
            where TEntity : class;

        /// <summary>
        /// Asynchronously applies any pending migration for the context to the database.
        /// </summary>
        /// <returns>A task that represents the asynchronous migration operation.</returns>
        Task UpdateDatabaseAsync();

        /// <summary>
        /// Commits all changes made by this repository to the database.
        /// </summary>
        /// <returns>A task that represents the asynchronous commit operation.</returns>
        Task<bool> CommitAsync();
    }
}
