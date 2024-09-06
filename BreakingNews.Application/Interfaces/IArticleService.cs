using BreakingNews.Application.DTOs;
using BreakingNews.Domain.Entities;

namespace BreakingNews.Application.Interfaces
{
    public interface IArticleService
    {
        Task AddAsync(CreateArticleDTO article);
        Task<Article> GetBySlug(string slug);
    }
}