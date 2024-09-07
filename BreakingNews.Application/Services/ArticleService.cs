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

        public new async Task<IEnumerable<ArticleDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ArticleDTO>>(await _articleRepository.GetAllAsync());
        }

        public new async Task<Article> GetByIdAsync(Guid id)
        {
            return _mapper.Map<Article>(await _articleRepository.GetByIdAsync(id));
        }

        public async Task<ArticleDTO> AddAsync(ArticleDTO dto)
        {
            var article = _mapper.Map<Article>(dto);

            article.ChangeStatus(ArticleStatus.Drafted);

            return _mapper.Map<ArticleDTO>(await _articleRepository.AddAsync(article));
        }

        public async Task<Article> GetBySlug(string slug)
        {
            return await _articleRepository.GetBySlug(slug);
        }
    }
}
