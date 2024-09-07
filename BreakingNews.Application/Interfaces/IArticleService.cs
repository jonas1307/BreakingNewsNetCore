using BreakingNews.Application.DTOs;
using BreakingNews.Domain.Entities;

namespace BreakingNews.Application.Interfaces
{
    public interface IArticleService : IBaseService<Article, Guid>
    {
        Task AddAsync(ArticleDTO article);
        new Task<IEnumerable<ArticleDTO>> GetAllAsync();
        Task<Article> GetByIdAsync(Guid id);
        Task<Article> GetBySlug(string slug);
    }
}