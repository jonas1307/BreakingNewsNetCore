using BreakingNews.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BreakingNews.Repository.Repositories
{
    public class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId> where TEntity : class
    {
        protected readonly BreakingNewsContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(BreakingNewsContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TId id)
        {
            var entity = await _dbSet.FindAsync(id);
            
            if (entity != null)
            {
                _dbSet.Remove(entity);
                
                await _context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> GetByIdAsync(TId id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
