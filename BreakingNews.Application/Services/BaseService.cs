using BreakingNews.Application.Interfaces;
using BreakingNews.Domain.Interfaces.Repositories;

namespace BreakingNews.Application.Services
{
    public class BaseService<TEntity, TId> : IDisposable, IBaseService<TEntity, TId> where TEntity : class
    {
        private IBaseRepository<TEntity, TId> _baseRepository;

        public BaseService(IBaseRepository<TEntity, TId> repository)
        {
            _baseRepository = repository;
        }

        public async Task AddAsync(TEntity obj)
        {
            await _baseRepository.AddAsync(obj);
        }

        public async Task UpdateAsync(TEntity obj)
        {
            await _baseRepository.UpdateAsync(obj);
        }

        public async Task DeleteAsync(TId obj)
        {
            await _baseRepository.DeleteAsync(obj);
        }

        public async Task<TEntity> GetByIdAsync(TId id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _baseRepository.GetAllAsync();
        }

        public void Dispose()
        {
            _baseRepository = null;
        }
    }
}
