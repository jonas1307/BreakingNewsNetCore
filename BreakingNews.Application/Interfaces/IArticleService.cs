﻿using BreakingNews.Application.DTOs;
using BreakingNews.Domain.Entities;

namespace BreakingNews.Application.Interfaces
{
    public interface IArticleService : IBaseService<Article, Guid>
    {
        Task<ArticleDTO> AddAsync(ArticleDTO article);
        new Task<IEnumerable<ArticleDTO>> GetAllAsync();
        Task<ArticleDTO> GetByIdAsync(Guid id);
        Task<ArticleDTO> GetBySlug(string slug);
        Task UpdateAsync(Guid id, ArticleDTO dto);
    }
}