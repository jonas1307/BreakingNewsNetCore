using Bogus;
using BreakingNews.Domain.Entities;
using BreakingNews.Repository;
using BreakingNews.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BreakingNews.IntegrationTests.Repositories
{
    public class BaseRepositoryTests
    {
        private readonly BreakingNewsContext _context;
        private readonly BaseRepository<Article, Guid> _repository;
        private readonly Faker Faker = new Faker();

        public BaseRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<BreakingNewsContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;

            var _context = new BreakingNewsContext(options);

            _context.Database.OpenConnection();
            _context.Database.EnsureCreated();

            _repository = new BaseRepository<Article, Guid>(_context);
        }

        [Fact]
        public async Task AddEntity_ShouldSaveEntity()
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
            article = await _repository.AddAsync(article);

            // Assert
            var savedArticle = await _repository.GetByIdAsync(article.Id);
            Assert.NotNull(savedArticle);
            Assert.Equal(article.Title, savedArticle.Title);
        }

        [Fact]
        public async Task UpdateEntity_ShouldChangeEntity()
        {
            // Arrange
            var initialOrder = new Article
            {
                Author = Faker.Person.FullName,
                Title = Faker.Lorem.Sentence(),
                Summary = Faker.Lorem.Sentence(15),
                Body = Faker.Lorem.Paragraphs(5, "."),
                Category = Faker.Lorem.Word(),
                Slug = Faker.Lorem.Slug()
            };

            await _repository.AddAsync(initialOrder);

            // Act
            var orderToUpdate = await _repository.GetByIdAsync(initialOrder.Id);
            orderToUpdate.Slug = Faker.Lorem.Slug();
            await _repository.UpdateAsync(orderToUpdate);

            // Assert
            var updatedOrder = await _repository.GetByIdAsync(initialOrder.Id);
            Assert.Equal(orderToUpdate.Slug, updatedOrder.Slug);
        }

        [Fact]
        public async Task DeleteEntity_ShouldRemoveEntity()
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

            article = await _repository.AddAsync(article);

            // Act
            await _repository.DeleteAsync(article.Id);
            var deletedArticle = await _repository.GetByIdAsync(article.Id);

            // Assert
            Assert.Null(deletedArticle);
        }

        [Fact]
        public async Task GetAllEntities_ShouldReturnAllEntities()
        {
            // Arrange
            var articles = new Faker<Article>()
                .RuleFor(x => x.Author, x => x.Person.FullName)
                .RuleFor(x => x.Title, x => x.Lorem.Sentence())
                .RuleFor(x => x.Summary, x => x.Lorem.Sentence(15))
                .RuleFor(x => x.Body, x => x.Lorem.Text())
                .RuleFor(x => x.Category, x => x.Lorem.Word())
                .RuleFor(x => x.Slug, x => x.Lorem.Slug());

            foreach (var item in articles.Generate(3))
            {
                await _repository.AddAsync(item);
            }

            // Act
            var articlesInDb = await _repository.GetAllAsync();

            // Assert
            Assert.Equal(3, articlesInDb.Count());
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}