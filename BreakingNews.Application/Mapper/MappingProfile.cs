using AutoMapper;
using BreakingNews.Application.DTOs;
using BreakingNews.Domain.Entities;

namespace BreakingNews.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Article, CreateArticleDTO>();
            CreateMap<CreateArticleDTO, Article>();
        }
    }
}
