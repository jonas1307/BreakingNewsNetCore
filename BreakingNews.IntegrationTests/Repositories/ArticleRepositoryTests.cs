using Bogus;
using BreakingNews.Domain.Entities;
using BreakingNews.Repository.Repositories;
using BreakingNews.Repository;
using Microsoft.EntityFrameworkCore;

namespace BreakingNews.IntegrationTests.Repositories
{
    public class ArticleRepositoryTests
    {
        private readonly BreakingNewsContext _context;
        private readonly ArticleRepository _repository;
        private readonly Faker Faker = new Faker();

        public ArticleRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<BreakingNewsContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;

            var _context = new BreakingNewsContext(options);

            _context.Database.OpenConnection();
            _context.Database.EnsureCreated();

            _repository = new ArticleRepository(_context);
        }

        [Fact]
        public async Task DuplicatedSlug_ThrowsDbUpdateException()
        {
            // Arrange
            var article = new Article
            {
                Author = Faker.Person.FullName,
                Title = Faker.Lorem.Sentence(),
                Summary = Faker.Lorem.Sentence(15),
                Body = Faker.Lorem.Paragraphs(5, "."),
                Category = Faker.Lorem.Word(),
                Slug = Faker.Lorem.Slug()
            };

            // Act
            await _repository.AddAsync(article);

            // Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await _repository.AddAsync(article);
            });
        }

        [Fact]
        public async Task GetBySlug_ShouldReturnArticle()
        {
            // Arrange
            var slug = Faker.Lorem.Slug();

            var article = new Article
            {
                Author = Faker.Person.FullName,
                Title = Faker.Lorem.Sentence(),
                Summary = Faker.Lorem.Sentence(15),
                Body = Faker.Lorem.Paragraphs(5, "."),
                Category = Faker.Lorem.Word(),
                Slug = slug
            };

            await _repository.AddAsync(article);

            // Act
            var articleInDb = await _repository.GetBySlug(slug);

            // Assert
            Assert.NotNull(articleInDb);
        }
    }
}
