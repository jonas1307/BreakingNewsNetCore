using BreakingNews.Application.Interfaces;
using BreakingNews.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace BreakingNews.Application.Utils
{
    [ExcludeFromCodeCoverage]
    public static class RepositoryServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            // Services DI
            services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));
            services.AddScoped<IArticleService, ArticleService>();

            return services;
        }
    }
}
