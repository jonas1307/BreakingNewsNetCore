using AutoMapper;
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

        public async Task AddAsync(CreateArticleDTO dto)
        public async Task AddAsync(ArticleDTO dto)
        {
            var article = _mapper.Map<Article>(dto);

            article.ChangeStatus(ArticleStatus.Drafted);

            await _articleRepository.AddAsync(article);
        }

        public async Task<Article> GetBySlug(string slug)
        {
            return await _articleRepository.GetBySlug(slug);
        }
    }
}
