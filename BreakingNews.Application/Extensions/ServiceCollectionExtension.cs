﻿using BreakingNews.Application.Interfaces;
using BreakingNews.Application.Mapper;
using BreakingNews.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace BreakingNews.Application.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Add AutoMapper
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            // Services DI
            services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));
            services.AddScoped<IArticleService, ArticleService>();

            return services;
        }
    }
}
