using BreakingNews.Domain.Entities;
using BreakingNews.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BreakingNews.Repository.Repositories
{
    public class ArticleRepository : BaseRepository<Article, Guid>, IArticleRepository
    {
        public ArticleRepository(BreakingNewsContext context) : base(context)
        {
        }

        public async Task<Article> GetBySlug(string slug)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Slug == slug);
        }
    }
}
