using BreakingNews.Domain.Entities;
using BreakingNews.Repository.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BreakingNews.Repository
{
    public class BreakingNewsContext : DbContext
    {
        public BreakingNewsContext()
        {
        }

        public BreakingNewsContext(DbContextOptions<BreakingNewsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Article> Articles { get; set; }
    }

    public sealed class BreakingNewsContextFactory : IDesignTimeDbContextFactory<BreakingNewsContext>
    {
        public BreakingNewsContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<BreakingNewsContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new BreakingNewsContext(optionsBuilder.Options);
        }
    }
}
