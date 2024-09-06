using BreakingNews.Domain.Entities;

namespace BreakingNews.Domain.Interfaces.Repositories
{
    public interface IArticleRepository : IBaseRepository<Article, Guid>
    {
        Task<Article> GetBySlug(string slug);
    }
}
