﻿using AutoMapper;
using BreakingNews.Application.DTOs;
using BreakingNews.Application.Interfaces;
using BreakingNews.Domain.Entities;
using BreakingNews.Domain.Enumerators;
using BreakingNews.Domain.Interfaces.Repositories;

namespace BreakingNews.Application.Services
{
    public class ArticleService : BaseService<Article, Guid>, IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public ArticleService(IArticleRepository articleRepository, IMapper mapper) : base(articleRepository)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public new async Task<IEnumerable<ArticleDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ArticleDTO>>(await _articleRepository.GetAllAsync());
        }

        public new async Task<ArticleDTO> GetByIdAsync(Guid id)
        {
            return _mapper.Map<ArticleDTO>(await _articleRepository.GetByIdAsync(id));
        }

        public async Task<ArticleDTO> AddAsync(ArticleDTO dto)
        {
            var article = _mapper.Map<Article>(dto);

            article.ChangeStatus(ArticleStatus.Drafted);

            return _mapper.Map<ArticleDTO>(await _articleRepository.AddAsync(article));
        }

        public async Task<ArticleDTO> GetBySlug(string slug)
        {
            return _mapper.Map<ArticleDTO>(await _articleRepository.GetBySlug(slug));
        }

        public async Task UpdateAsync(Guid id, ArticleDTO dto)
        {
            var article = await _articleRepository.GetByIdAsync(id);

            await _articleRepository.UpdateAsync(_mapper.Map(dto, article));
        }
    }
}
