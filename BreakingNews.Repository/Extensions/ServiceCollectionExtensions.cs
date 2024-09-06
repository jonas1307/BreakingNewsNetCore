using BreakingNews.Domain.Interfaces.Repositories;
using BreakingNews.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace BreakingNews.Repository.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Entity Framework
            services.AddDbContext<BreakingNewsContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("BreakingNewsContext")));

            // Repositories DI
            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            services.AddScoped<IArticleRepository, ArticleRepository>();

            return services;
        }
    }
}
