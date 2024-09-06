using Bogus;
using BreakingNews.Application.Services;
using BreakingNews.Domain.Entities;
using BreakingNews.Domain.Interfaces.Repositories;
using Moq;

namespace BreakingNews.UnitTests.Services
{
    public class BaseServiceTests
    {
        private readonly BaseService<Article, Guid> _service;
        private readonly Faker Faker = new Faker();
        private readonly Mock<IBaseRepository<Article, Guid>> _repositoryMock = new Mock<IBaseRepository<Article, Guid>>();

        public BaseServiceTests()
        {
            _service = new BaseService<Article, Guid>(_repositoryMock.Object);
        }

        [Fact]
        public async Task AddEntity_ShouldCallAddAsync()
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
            await _service.AddAsync(article);

            // Assert
            _repositoryMock.Verify(x => x.AddAsync(article), Times.Once());
        }
    }
}