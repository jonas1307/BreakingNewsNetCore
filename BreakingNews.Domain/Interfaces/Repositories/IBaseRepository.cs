namespace BreakingNews.Domain.Interfaces.Repositories
{
    /// <summary>
    /// A base interface for repository operations.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity being managed.</typeparam>
    public interface IBaseRepository<TEntity, TId> where TEntity : class
    {
        /// <summary>
        /// Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Deletes an entity from the repository by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to delete.</param>
        Task DeleteAsync(TId id);

        /// <summary>
        /// Retrieves an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to retrieve.</param>
        /// <returns>The entity if found; otherwise, null.</returns>
        Task<TEntity> GetByIdAsync(TId id);

        /// <summary>
        /// Retrieves all entities from the repository.
        /// </summary>
        /// <returns>A collection of all entities.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}

