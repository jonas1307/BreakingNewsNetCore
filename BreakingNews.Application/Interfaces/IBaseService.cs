namespace BreakingNews.Application.Interfaces
{
    public interface IBaseService<TEntity, TId> where TEntity : class
    {
        Task AddAsync(TEntity obj);
        Task DeleteAsync(TId obj);
        void Dispose();
        Task<TEntity> GetByIdAsync(TId id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity obj);
    }
}